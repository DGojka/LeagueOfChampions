namespace LeagueOfChampions.spell;

public interface ISpellProvider {
    Spell? ProvideBasicAttack();

    Spell? ProvideQ();

    Spell? ProvideW();

    Spell? ProvideE();

    Spell? ProvideR();

    Spell ProvidePassive();
}