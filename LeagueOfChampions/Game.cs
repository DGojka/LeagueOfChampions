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
        subtitlesPrinter.PrintStartBattle();
        int turnCount = 0;
        while (!SomeChampionDied()) {
            subtitlesPrinter.PrintTurn(championInMove.Name);
            turnCount++;
            if (IsNewRound(turnCount)) {
                SetupNewRound(championInMove, attackedChampion);
            }

            while (!IsTurnOver(championInMove, attackedChampion)) {
                subtitlesPrinter.PrintActionPoints(championInMove.CurrentManaPoints);
                subtitlesPrinter.PrintTypeHelp();
                KeyType key = KeyboardManager.GetKey();
                HandleKeyResult(key, championInMove, attackedChampion);
            }

            (championInMove, attackedChampion) = (attackedChampion, championInMove);
        }

        var winner = DetermineWinner();
        subtitlesPrinter.PrintWinner(winner.Name);
    }

    private void HandleKeyResult(KeyType key, Champion championInMove, Champion attackedChampion) {
        switch (key) {
            case KeyType.INFO:
                subtitlesPrinter.PrintChampionInfo(championInMove.SpellsExplanation);
                break;
            case KeyType.UNKNOWN:
                subtitlesPrinter.PrintWrongKey();
                break;
            default:
                Spell spell = GetSpell(championInMove, key);
                spell.Use();
                attackedChampion.ReceiveSpell(spell.SpellDescription);
                PrintChampionsHp();
                break;
        }
    }

    private void HandleOtherKeyOptions(KeyType key, Champion championInMove) {
        switch (key) {
            case KeyType.INFO:
                subtitlesPrinter.PrintChampionInfo(championInMove.SpellsExplanation);
                break;
        }
    }

    private Spell GetSpell(Champion champion, KeyType key) {
        Spell? spell;
        do {
            spell = key switch {
                KeyType.T => champion.BaseAttackHandler(),
                KeyType.Q => champion.SpellQHandler(),
                KeyType.W => champion.SpellWHandler(),
                KeyType.E => champion.SpellEHandler(),
                KeyType.R => champion.SpellRHandler(),
                _ => null,
            };
        } while (spell == null);

        return spell;
    }

    private bool isSpellKey(KeyType key) {
        return key != KeyType.INFO && key != KeyType.UNKNOWN;
    }

    private void SetupNewRound(Champion championInMove, Champion attackedChampion) {
        _roundCount++;
        Console.Clear();

        ResetAbilities(championInMove, attackedChampion);
        UsePassiveSpells(championInMove, attackedChampion);
        PrintOnBeginningOfTheRound();
    }

    private bool SomeChampionDied() {
        return champion1.CurrentHp <= 0 || champion2.CurrentHp <= 0;
    }

    private Champion DetermineWinner() {
        return champion1.CurrentHp < champion2.CurrentHp ? champion2 : champion1;
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

    private bool IsTurnOver(Champion championInMove, Champion attackedChampion) {
        return championInMove.CurrentManaPoints <= 0 || attackedChampion.CurrentHp <= 0;
    }

    private static bool IsNewRound(int turnCount) {
        return turnCount % 2 != 0;
    }

    private void PrintChampionsHp() {
        subtitlesPrinter.PrintEnter(1);
        subtitlesPrinter.PrintHp(champion2);
        subtitlesPrinter.PrintHp(champion1);
    }

    private void PrintOnBeginningOfTheRound() {
        subtitlesPrinter.PrintHp(champion1);
        subtitlesPrinter.PrintHp(champion2);
        subtitlesPrinter.PrintEnter(1);
        subtitlesPrinter.PrintRoundCount(_roundCount);
        subtitlesPrinter.PrintEnter(1);
        subtitlesPrinter.PrintTurn(champion1.Name);
    }
}