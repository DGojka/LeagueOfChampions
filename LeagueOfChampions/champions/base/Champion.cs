using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions.@base {
    public abstract class Champion : ISpellProvider {
        protected readonly SubtitlesPrinter SubtitlesPrinter;

        protected string Name;

        // Getters, Setters
        public string GetName() {
            return Name;
        }

        public float GetHp() {
            return CurrentHp;
        }

        public int GetCurrentManaPoints() {
            return CurrentManaPoints;
        }

        public override string ToString() {
            return Name;
        }
        // HP
        protected int MaxHp;
        protected int CurrentHp;

        // Mana Points and Cooldowns
        protected int ManaPoints;
        protected int CurrentManaPoints;

        // Defense
        protected int Armor;

        // Damage
        protected int AttackDamage;
        protected float ArmorPenetration;

        protected Spell? BasicAttack;
        protected Spell? SpellQ;
        protected Spell? SpellW;
        protected Spell? SpellE;
        protected Spell? SpellR;
        protected Spell? PassiveSpell;

        public abstract Spell? ProvideBasicAttack();
        public abstract Spell? ProvideQ();
        public abstract Spell? ProvideW();
        public abstract Spell? ProvideE();
        public abstract Spell? ProvideR();
        public abstract Spell ProvidePassive();

        protected Champion(SubtitlesPrinter subtitlesPrinter) {
            SubtitlesPrinter = subtitlesPrinter;
        }

        public void ReceiveSpell(SpellDescription description) {
            int relativeArmor =
                (int)((Armor * (1 - description.ArmorPen * 0.01)) / 2);
            relativeArmor = relativeArmor == 0 ? 1 : relativeArmor;
            if (description.DamageByMissingHp && description.TrueDmg) {
                int damageByMissingHp = (int)(description.AttackDamage *
                                              (1.1 - GetHpPercentage()));
                CurrentHp -= damageByMissingHp;
            } else if (description.DamageByMissingHp) {
                int adDamageByMissingHp = (int)(description.AttackDamage *
                                                (1.1 - GetHpPercentage()));
                CurrentHp -= adDamageByMissingHp / relativeArmor;
            } else {
                if (description.TrueDmg) {
                    CurrentHp -= description.AttackDamage;
                } else {
                    CurrentHp -= description.AttackDamage / relativeArmor;
                }
            }
        }

        public Spell? BaseAttackHandler() {
            Spell? aa = ProvideBasicAttack();
            if (BasicAttack != null)
                CurrentManaPoints -= BasicAttack.ManaPointsCost;
            return aa;
        }

        public Spell? SpellQHandler() {
            Spell? spell = ProvideQ();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            } else {
                SubtitlesPrinter.SpellOnCooldown();
                return new Spell(new SpellDescription(), 0, () => { });
            }
        }

        public Spell? SpellWHandler() {
            Spell? spell = ProvideW();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            } else {
                SubtitlesPrinter.SpellOnCooldown();
                return new Spell(new SpellDescription(), 0, () => { });
            }
        }

        public Spell? SpellEHandler() {
            Spell? spell = ProvideE();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            } else {
                SubtitlesPrinter.SpellOnCooldown();
                return new Spell(new SpellDescription(), 0, () => { });
            }
        }

        public Spell? SpellRHandler() {
            Spell? spell = ProvideR();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            } else {
                SubtitlesPrinter.SpellOnCooldown();
                return new Spell(new SpellDescription(), 0, () => { });
            }
        }

        // Reset
        public void ResetCurrentManaPoints() {
            CurrentManaPoints = ManaPoints;
        }

        // Cooldowns
        public void ResetCooldowns() {
            if (SpellQ != null) SpellQ.IsSpellOnCooldown = false;
            if (SpellW != null) SpellW.IsSpellOnCooldown = false;
            if (SpellE != null) SpellE.IsSpellOnCooldown = false;
            if (SpellR != null) SpellR.IsSpellOnCooldown = false;
        }

        private bool SpellCanBeUsed(Spell? spell) {
            return spell is { IsSpellOnCooldown: false } &&
                   CurrentManaPoints >= spell.ManaPointsCost;
        }

        private void UseManaAndCooldown(Spell? spell) {
            if (spell == null) return;
            CurrentManaPoints -= spell.ManaPointsCost;
            spell.IsSpellOnCooldown = true;
        }

        private int GetHpPercentage() {
            return CurrentHp / MaxHp;
        }
    }
}