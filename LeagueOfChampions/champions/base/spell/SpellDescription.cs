namespace LeagueOfChampions.spell;

public class SpellDescription {
    public int AttackDamage { get; set; }
    public bool TrueDmg { get; set; }
    public float ArmorPen { get; set; }
    public bool DamageByMissingHp { get; set; }

    public SpellDescription(int attackDamage, int apDmg, bool trueDmg, float armorPen,
        float magicPen, bool damageByMissingHp) {
        AttackDamage = attackDamage;
        TrueDmg = trueDmg;
        ArmorPen = armorPen;
        DamageByMissingHp = damageByMissingHp;
    }

    public SpellDescription() {
        AttackDamage = 0;
        TrueDmg = false;
        ArmorPen = 0;
        DamageByMissingHp = false;
    }
}