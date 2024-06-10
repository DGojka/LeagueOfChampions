using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions;

public class Game {
    private readonly Champion champion1;
    private readonly Champion champion2;
    private int _roundCount;
    private readonly SubtitlesPrinter subtitlesPrinter;

    public Game(Champion champion1, Champion champion2, SubtitlesPrinter subtitlesPrinter) {
        this.subtitlesPrinter = subtitlesPrinter;
        this.champion1 = champion1;
        this.champion2 = champion2;
    }

    public void Start() {
        Champion championInMove = champion1;
        Champion attackedChampion = champion2;

        int turnCount = 0;
        while (!SomeChampionDied()) {
            turnCount++;
            if (turnCount % 2 != 0) {
                _roundCount++;
                Console.Clear();
                
                ResetAbilities(championInMove, attackedChampion);
                UsePassiveSpells(championInMove, attackedChampion);
                PrintOnBeginningOfTheRound();
            }

            while (championInMove.GetCurrentManaPoints() > 0 && attackedChampion.GetHp() > 0) {
                subtitlesPrinter.PrintActionPoints(championInMove.GetCurrentManaPoints());
                Spell? spell;
                do {
                    spell = GetSpell(KeyboardManager.GetKey(), championInMove);
                } while (spell == null);

                spell.Use();
                attackedChampion.ReceiveSpell(spell.SpellDescription);
                subtitlesPrinter.PrintEnter(1);
                subtitlesPrinter.PrintHp(champion2);
                subtitlesPrinter.PrintHp(champion1);
            }
            if (SomeChampionDied()) {
                Champion winner = DetermineWinner();
                subtitlesPrinter.PrintWinner(winner.GetName());
            } else {
                (championInMove, attackedChampion) = (attackedChampion, championInMove);
                subtitlesPrinter.PrintTurn(championInMove.GetName());
            }
        }
    }

    private Spell? GetSpell(KeyType type, Champion champion) {
        return type switch {
            KeyType.T => champion.BaseAttackHandler(),
            KeyType.Q => champion.SpellQHandler(),
            KeyType.W => champion.SpellWHandler(),
            KeyType.E => champion.SpellEHandler(),
            KeyType.R => champion.SpellRHandler(),
            _ => null,
        };
    }

    private bool SomeChampionDied() {
        return champion1.GetHp() <= 0 || champion2.GetHp() <= 0;
    }

    private Champion DetermineWinner() {
        return champion1.GetHp() < champion2.GetHp() ? champion2 : champion1;
    }
    
    private void ResetAbilities(Champion championInMove, Champion attackedChampion) {
        championInMove.ResetCurrentManaPoints();
        attackedChampion.ResetCurrentManaPoints();
        championInMove.ResetCooldowns();
        attackedChampion.ResetCooldowns();
    }

    private void UsePassiveSpells(Champion championInMove, Champion attackedChampion) {
        championInMove.ProvidePassive().Use();
        attackedChampion.ProvidePassive().Use();
    }

    private void PrintOnBeginningOfTheRound() {
        subtitlesPrinter.PrintHp(champion1);
        subtitlesPrinter.PrintHp(champion2);
        subtitlesPrinter.PrintEnter(1);
        subtitlesPrinter.PrintRoundCount(_roundCount);
        subtitlesPrinter.PrintEnter(1);
        subtitlesPrinter.PrintTurn(champion1.GetName());
    }
}