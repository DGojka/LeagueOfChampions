namespace LeagueOfChampions.spell;

public class Spell {
    public SpellDescription SpellDescription { get; set; }
    public int ManaPointsCost { get; set; }
    public bool IsSpellOnCooldown { get; set; }
    private readonly Action _spellListener;

    public Spell(SpellDescription spellDescription, int manaPointsCost, Action spellListener) {
        SpellDescription = spellDescription;
        ManaPointsCost = manaPointsCost;
        IsSpellOnCooldown = false;
        _spellListener = spellListener;
    }

    public void Use() {
        _spellListener();
    }
}