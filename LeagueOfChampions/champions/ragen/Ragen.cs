using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions.ragen;

public class Ragen : Champion {
    private readonly SubtitlesPrinter _subtitlesPrinter;

    public Ragen(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = RagenConstants.RAGEN;
        MaxHp = RagenConstants.MAX_HP;
        CurrentHp = RagenConstants.MAX_HP;
        Armor = RagenConstants.ARMOR;
        AttackDamage = RagenConstants.ATTACK_DAMAGE;
        ManaPoints = RagenConstants.MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
        SpellsExplanation = new RagenSpellsExplanation();
    }

    public override Spell ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                RagenConstants.BasicAttackManaCost, () => { });
    }

    public override Spell ProvideQ() {
        return SpellQ ??=
            new Spell(
                new SpellDescription(RagenConstants.QDamage, false, false),
                RagenConstants.QManaCost, () => { });
    }

    public override Spell ProvideW() {
        return SpellW ??=
            new Spell(new SpellDescription(), RagenConstants.WManaCost,
                () => { Armor += RagenConstants.WArmorGain; });
    }

    public override Spell ProvideE() {
        var spinsDamage = 0;
        var spinsCount =
            MathHelper.RandomInt(RagenConstants.MinSpinsCount, RagenConstants.MaxSpinsCount);
        _subtitlesPrinter.RagenPrintSpinsCount(spinsCount);
        for (var i = RagenConstants.MinSpinsCount; i < spinsCount; i++) {
            spinsDamage += RagenConstants.SingleSpinDamage;
        }

        return new Spell(new SpellDescription(spinsDamage, false, false), RagenConstants.EManaCost,
            () => { });
    }

    public override Spell ProvideR() {
        return SpellR ??=
            new Spell(new SpellDescription(RagenConstants.RDamage, true, true),
                RagenConstants.RManaCost, () => { });
    }

    public override Spell ProvidePassive() {
        return PassiveSpell ??= new Spell(new SpellDescription(),
            0, () => {
                if (CurrentHp <= RagenConstants.MinHpToUsePassive) {
                    var regeneratedHp = (int)((MaxHp - CurrentHp) * 0.035);
                    CurrentHp += regeneratedHp;
                    _subtitlesPrinter.RagenPrintPassive(regeneratedHp);
                }

                Armor++;
            });
    }
}