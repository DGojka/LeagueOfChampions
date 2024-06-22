using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;
using static RayZConstants;
public class RayZ : Champion {
    private readonly SubtitlesPrinter _subtitlesPrinter;

    public RayZ(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = NAME;
        MaxHp = MAX_HP;
        CurrentHp = MAX_HP;
        Armor = ARMOR;
        AttackDamage = ATTACK_DAMAGE;
        ManaPoints = MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
        SpellsExplanation = new RayZSpellsExplanation();
    }

    private bool _isMarkUsed;

    public override Spell? ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                BasicAttackManaCost, () => { });
    }

    public override Spell? ProvideQ() {
        var damage = _isMarkUsed ? QMarkedDamage : QBaseDamage;
        return new Spell(new SpellDescription(damage, false, false), QManaCost,
            () => { _isMarkUsed = false; });
    }

    public override Spell? ProvideW() {
        return new Spell(new SpellDescription(), WManaCost, () => {
            {
                int randomNumber = MathHelper.RandomInt(1, 6);
                switch (randomNumber) {
                    case 1:
                        AttackDamage += WDamageGain;
                        _subtitlesPrinter.RayZGainsAd();
                        break;
                    case 2:
                        _isMarkUsed = true;
                        _subtitlesPrinter.EnemyMarked();
                        break;
                    case 3:
                        Armor += WArmorGain;
                        _subtitlesPrinter.RayZGainedArmor();
                        break;
                    case 4:
                        ResetCooldown(SpellE);
                        CurrentManaPoints++;
                        _subtitlesPrinter.RayZResetECooldown();
                        _subtitlesPrinter.RayZGainsManaPoint();
                        break;
                    case 5:
                        CurrentManaPoints++;
                        _subtitlesPrinter.RayZGainsManaPoint();
                        break;
                    case 6:
                        _subtitlesPrinter.RayZBurnedScroll();
                        break;
                }
            }
        });
    }

    public override Spell? ProvideE() {
        return SpellE ??=
            new Spell(
                new SpellDescription(EDamage, false, false),
                EManaCost, () => {
                    _isMarkUsed = true;
                    ResetCooldown(SpellQ);
                });
    }

    public override Spell? ProvideR() {
        return SpellR ??=
            new Spell(
                new SpellDescription(),
                CurrentManaPoints, () => {
                    CurrentManaPoints = ManaPoints;
                });
    }

    public override Spell ProvidePassive() {
        return PassiveSpell ??=
            new Spell(
                new SpellDescription(),
                0, () => {
                    var gainedAd = MathHelper.RandomInt(1, 5);
                    AttackDamage += gainedAd;
                    _subtitlesPrinter.RayZPrintPassive(gainedAd);
                });
    }
}