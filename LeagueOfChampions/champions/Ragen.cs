using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

public class Ragen : Champion {
    private const string RAGEN = "Ragen";
    private SubtitlesPrinter _subtitlesPrinter;

    //stats
    private const int MAX_HP = 400;
    private const int ATTACK_DAMAGE = 20;
    private const int ARMOR = 40;
    private const int MAX_MANA = 4;

    //mana costs
    private const int BasicAttackManaCost = 1;
    private const int QManaCost = 2;
    private const int WManaCost = 1;
    private const int EManaCost = 2;
    private const int RManaCost = MAX_MANA;

    //spells
    //Q
    private const int QDamage = ATTACK_DAMAGE * 3;

    //W
    private const int WArmorGain = 2;

    //E
    private const int SingleSpinDamage = 7;
    private const int MinSpinsCount = 0;

    private const int MaxSpinsCount = 13;

    //R
    private const int RDamage = 50;

    //PASSIVE
    private const int MinHpToUsePassive = MAX_HP - 30;

    public Ragen(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter, RAGEN) {
        MaxHp = MAX_HP;
        CurrentHp = MAX_HP;
        Armor = ARMOR;
        AttackDamage = ATTACK_DAMAGE;
        ManaPoints = MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
    }

    public override Spell? ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false), BasicAttackManaCost, () => { });
    }

    public override Spell ProvideQ() {
        return SpellQ ??=
            new Spell(
                new SpellDescription(QDamage, false, false), QManaCost, () => { });
    }

    public override Spell ProvideW() {
        return SpellW ??=
            new Spell(new SpellDescription(), WManaCost, () => { Armor += WArmorGain; });
    }

    public override Spell ProvideE() {
        var spinsDamage = 0;
        var spinsCount = MathHelper.RandomInt(MinSpinsCount, MaxSpinsCount);
        _subtitlesPrinter.RagenPrintSpinsCount(spinsCount);
        for (var i = MinSpinsCount; i < spinsCount; i++) {
            spinsDamage += SingleSpinDamage;
        }

        SpellE = new Spell(new SpellDescription(spinsDamage, false, false), EManaCost, () => { });

        return SpellE;
    }

    public override Spell ProvideR() {
        return SpellR ??=
            new Spell(new SpellDescription(RDamage, true, true), RManaCost, () => { });
    }

    public override Spell ProvidePassive() {
        return PassiveSpell ??= new Spell(new SpellDescription(),
            0, () => {
                if (CurrentHp <= MinHpToUsePassive) {
                    int regeneratedHp = (int)((MaxHp - CurrentHp) * 0.035);
                    CurrentHp += regeneratedHp;
                    _subtitlesPrinter.RagenPrintPassive(regeneratedHp);
                }

                Armor++;
            });
    }
}