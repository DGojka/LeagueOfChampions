namespace LeagueOfChampions.spell;

public class Spell {
    public SpellDescription SpellDescription { get; set; }
    public int ManaPointsCost { get; set; }
    public bool IsSpellOnCooldown { get; set; }
    public Action OnSpellUsed { get; set; }

    public Spell(SpellDescription spellDescription, int manaPointsCost, Action onSpellUsed) {
        SpellDescription = spellDescription;
        ManaPointsCost = manaPointsCost;
        IsSpellOnCooldown = false;
        OnSpellUsed = onSpellUsed;
    }

    public void Use() {
        OnSpellUsed();
    }
}