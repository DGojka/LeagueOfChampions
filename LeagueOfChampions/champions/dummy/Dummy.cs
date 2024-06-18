using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

public class Dummy : Champion {
    private const string DUMMY = "DUMMY";
    private const int MAX_HP = 500;
    private const int MAX_MANA = 4;
    private const int ARMOR = 10;
    private const int MAX_AD = 20;

    public Dummy(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = DUMMY;
        MaxHp = MAX_HP;
        CurrentHp = MAX_HP;
        Armor = ARMOR;
        AttackDamage = MAX_AD;
        ManaPoints = MAX_MANA;
        CurrentManaPoints = ManaPoints;
        SpellsExplanation = new DummySpellsExplanation();
    }

    public override Spell? ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }

    public override Spell ProvideQ() {
        return SpellQ ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }

    public override Spell ProvideW() {
        return SpellW ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }

    public override Spell ProvideE() {
        return SpellE ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }

    public override Spell ProvideR() {
        return SpellR ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }

    public override Spell ProvidePassive() {
        return PassiveSpell ??=
            new Spell(new SpellDescription(), ManaPoints, () => { });
    }
}