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

        protected int Armor;
        protected int AttackDamage;

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

        protected Champion(SubtitlesPrinter subtitlesPrinter, string name) {
            SubtitlesPrinter = subtitlesPrinter;
            Name = name;
        }

        public void ReceiveSpell(SpellDescription description) {
            var damageTaken = CalculateDamageDealt(description.Damage, Armor,
                description.IsDamageByMissingHp, description.IsTrueDmg);
            CurrentHp -= damageTaken;
            if (damageTaken > 0) {
                SubtitlesPrinter.DamageTaken(Name, damageTaken);
            }
        }

        public Spell? BaseAttackHandler() {
            var basicAttack = ProvideBasicAttack();
            if (BasicAttack != null)
                CurrentManaPoints -= BasicAttack.ManaPointsCost;
            return basicAttack;
        }

        public Spell? SpellQHandler() {
            var spell = ProvideQ();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            }

            SubtitlesPrinter.SpellOnCooldown();
            return new Spell(new SpellDescription(), 0, () => { });
        }

        public Spell? SpellWHandler() {
            var spell = ProvideW();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            }

            SubtitlesPrinter.SpellOnCooldown();
            return new Spell(new SpellDescription(), 0, () => { });
        }

        public Spell? SpellEHandler() {
            var spell = ProvideE();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            }

            SubtitlesPrinter.SpellOnCooldown();
            return new Spell(new SpellDescription(), 0, () => { });
        }

        public Spell? SpellRHandler() {
            var spell = ProvideR();
            if (SpellCanBeUsed(spell)) {
                UseManaAndCooldown(spell);
                return spell;
            }

            SubtitlesPrinter.SpellOnCooldown();
            return new Spell(new SpellDescription(), 0, () => { });
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

        private int CalculateDamageDealt(int attackDamage, int relativeArmor,
            bool isDamageByMissingHp, bool isTrueDamage) {
            int damageDealt;
            switch (isDamageByMissingHp) {
                case true when isTrueDamage: {
                    damageDealt = (int)(attackDamage * (1.1 - GetHpPercentage()));
                    break;
                }
                case true: {
                    damageDealt = (int)(attackDamage * (1.1 - GetHpPercentage())) / relativeArmor;
                    break;
                }
                default: {
                    if (isTrueDamage) {
                        damageDealt = attackDamage;
                    } else {
                        damageDealt = attackDamage / relativeArmor;
                    }

                    break;
                }
            }

            return damageDealt;
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