using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

using static WladymyrConstants;

public class Wladymyr : Champion {
    private readonly SubtitlesPrinter _subtitlesPrinter;

    public Wladymyr(SubtitlesPrinter subtitlesPrinter) : base(subtitlesPrinter) {
        Name = NAME;
        MaxHp = MAX_HP;
        CurrentHp = MAX_HP;
        Armor = ARMOR;
        AttackDamage = ATTACK_DAMAGE;
        ManaPoints = MAX_MANA;
        CurrentManaPoints = ManaPoints;
        _subtitlesPrinter = subtitlesPrinter;
        SpellsExplanation = new WladymyrSpellsExplanation();
    }

    public override Spell ProvideBasicAttack() {
        return BasicAttack ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                BasicAttackManaCost, () => { });
    }

    public override Spell ProvideQ() {
        if (SpellQ == null) {
            return SpellQ = new Spell(new SpellDescription(AttackDamage * 2, false, false),
                QManaCost,
                OnSpellQUsed);
        }

        SpellQ.OnSpellUsed = OnSpellQUsed;
        return SpellQ;
    }

    public override Spell ProvideW() {
        return SpellW ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                WManaCost, () => {
                    var hpCost = (int)(MaxHp * 0.05);
                    CurrentHp -= hpCost;
                    _subtitlesPrinter.WladymyrUsedBlood(hpCost);

                    var hpPercentage = (double)CurrentHp / MaxHp;
                    var adGain = hpPercentage switch {
                        < W6LevelHpThreshold => W6LevelAdGain,
                        < W5LevelHpThreshold => W5LevelAdGain,
                        < W4LevelHpThreshold => W4LevelAdGain,
                        < W3LevelHpThreshold => W3LevelAdGain,
                        < W2LevelHpThreshold => W2LevelAdGain,
                        _ => W1LevelAdGain
                    };

                    IncreaseAttackDamage(adGain);
                });
    }

    public override Spell ProvideE() {
        return SpellE ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                EManaCost, () => {
                    var hpGain = (int)(ATTACK_DAMAGE * 0.1);
                    AttackDamage -= SpellEExchangedAd;
                    CurrentHp += hpGain;
                    _subtitlesPrinter.WladymyrExchangedAdForHP(SpellEExchangedAd, hpGain);
                });
    }

    public override Spell ProvideR() {
        return SpellR ??=
            new Spell(
                new SpellDescription(AttackDamage, false, false),
                RManaCost, () => {
                    if (AttackDamage > 100) {
                        AttackDamage -= 60;
                        CurrentHp -= 60;
                    } else {
                        _subtitlesPrinter.WladymyrNotEnoughAp();
                    }
                });
    }

    public override Spell ProvidePassive() {
        if (PassiveSpell == null) {
            return new Spell(
                new SpellDescription(),
                0, OnPassiveUsed);
        }

        PassiveSpell.OnSpellUsed = OnPassiveUsed;
        return PassiveSpell;
    }

    private void OnSpellQUsed() {
        var hpCost = (int)(0.05 * CurrentHp);
        CurrentHp -= hpCost;
        _subtitlesPrinter.WladymyrUsedBlood(hpCost);
        var absoluteDamageDealt = 2 * AttackDamage;
        var damageHealed = (int)(absoluteDamageDealt * 0.1);
        CurrentHp += damageHealed;
        _subtitlesPrinter.WladymyrHealed(damageHealed);
    }

    private void OnPassiveUsed() {
        if (MaxHp * 0.5 >= CurrentHp) {
            AttackDamage += PassiveGainedAd;
            _subtitlesPrinter.WladymyrPrintPassiveGainedAd(AttackDamage);
        } else {
            CurrentHp -= PassiveLostBlood;
            _subtitlesPrinter.WladymyrPrintPassiveLostBlood(PassiveLostBlood);
        }
    }

    private void IncreaseAttackDamage(int adGain) {
        AttackDamage += adGain;
        _subtitlesPrinter.WladymyrGainedAp(adGain, AttackDamage);
    }
}