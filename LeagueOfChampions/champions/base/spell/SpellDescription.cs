namespace LeagueOfChampions.spell;

public class SpellDescription {
    public int Damage { get; }
    public bool IsTrueDmg { get; }
    public bool IsDamageByMissingHp { get; }

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