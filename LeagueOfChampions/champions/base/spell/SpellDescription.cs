namespace LeagueOfChampions.spell;

public class SpellDescription {
    public int Damage { get; set; }
    public bool IsTrueDmg { get; set; }
    public bool IsDamageByMissingHp { get; set; }

    public SpellDescription(int damage, bool isTrueDmg, bool isDamageByMissingHp) {
        Damage = damage;
        IsTrueDmg = isTrueDmg;
        IsDamageByMissingHp = isDamageByMissingHp;
    }

    public SpellDescription() {
        Damage = 0;
        IsTrueDmg = false;
        IsDamageByMissingHp = false;
    }
}