namespace LeagueOfChampions.spell;

public class Spell {
    public SpellDescription SpellDescription { get; set; }
    public int ManaPointsCost { get; set; }
    public bool IsSpellOnCooldown { get; set; }
    private readonly Action _onSpellUsed;

    public Spell(SpellDescription spellDescription, int manaPointsCost, Action onSpellUsed) {
        SpellDescription = spellDescription;
        ManaPointsCost = manaPointsCost;
        IsSpellOnCooldown = false;
        _onSpellUsed = onSpellUsed;
    }

    public void Use() {
        _onSpellUsed();
    }
}