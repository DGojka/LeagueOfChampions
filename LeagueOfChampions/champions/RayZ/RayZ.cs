using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

public class RayZ : Champion {
    private readonly SubtitlesPrinter _subtitlesPrinter;

    public RayZ(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = RayZConstants.NAME;
        MaxHp = RayZConstants.MAX_HP;
        CurrentHp = RayZConstants.MAX_HP;
        Armor = RayZConstants.ARMOR;
        AttackDamage = RayZConstants.ATTACK_DAMAGE;
        ManaPoints = RayZConstants.MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
        SpellsExplanation = new RayZSpellsExplanation();
    }

    private bool isMarkUsed = false;

    public override Spell? ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                RayZConstants.BasicAttackManaCost, () => { });
    }

    public override Spell? ProvideQ() {
        var damage = isMarkUsed ? RayZConstants.QMarkedDamage : RayZConstants.QBaseDamage;
        return new Spell(new SpellDescription(damage, false, false), RayZConstants.QManaCost,
            () => { isMarkUsed = false; });
    }

    public override Spell? ProvideW() {
        // todo some random 5 usages, for example reset Q cooldown or gain mana/ap
        throw new NotImplementedException();
    }

    public override Spell? ProvideE() {
        return SpellE ??=
            new Spell(
                new SpellDescription(RayZConstants.EDamage, false, false),
                RayZConstants.EManaCost, () => {
                    isMarkUsed = true;
                    ResetCooldown(SpellQ);
                });
    }

    public override Spell? ProvideR() {
        //todo usage?
        throw new NotImplementedException();
    }

    public override Spell ProvidePassive() {
        //todo gain bonus attack damage each round
        throw new NotImplementedException();
    }
}