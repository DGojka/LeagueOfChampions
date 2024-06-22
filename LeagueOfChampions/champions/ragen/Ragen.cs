using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions.ragen;
using static RagenConstants;
public class Ragen : Champion {
    private readonly SubtitlesPrinter _subtitlesPrinter;

    public Ragen(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = RAGEN;
        MaxHp = MAX_HP;
        CurrentHp = MAX_HP;
        Armor = ARMOR;
        AttackDamage = ATTACK_DAMAGE;
        ManaPoints = MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
        SpellsExplanation = new RagenSpellsExplanation();
    }

    public override Spell ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                BasicAttackManaCost, () => { });
    }

    public override Spell ProvideQ() {
        return SpellQ ??=
            new Spell(
                new SpellDescription(QDamage, false, false),
                QManaCost, () => { });
    }

    public override Spell ProvideW() {
        return SpellW ??=
            new Spell(new SpellDescription(), WManaCost,
                () => { Armor += WArmorGain; });
    }

    public override Spell ProvideE() {
        var spinsDamage = 0;
        var spinsCount =
            MathHelper.RandomInt(MinSpinsCount, MaxSpinsCount);
        _subtitlesPrinter.RagenPrintSpinsCount(spinsCount);
        for (var i = MinSpinsCount; i < spinsCount; i++) {
            spinsDamage += SingleSpinDamage;
        }

        return new Spell(new SpellDescription(spinsDamage, false, false), RagenConstants.EManaCost,
            () => { });
    }

    public override Spell ProvideR() {
        return SpellR ??=
            new Spell(new SpellDescription(RDamage, true, true),
                RManaCost, () => { });
    }

    public override Spell ProvidePassive() {
        return PassiveSpell ??= new Spell(new SpellDescription(),
            0, () => {
                if (CurrentHp <= MinHpToUsePassive) {
                    var regeneratedHp = (int)((MaxHp - CurrentHp) * 0.035);
                    CurrentHp += regeneratedHp;
                    _subtitlesPrinter.RagenPrintPassive(regeneratedHp);
                }

                Armor++;
            });
    }
}