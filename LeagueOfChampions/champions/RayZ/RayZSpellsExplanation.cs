using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

public class RayZSpellsExplanation : SpellsExplanation {
    public string GetQExplanation() {
        return
            $"Q deals doubled damage. If enemy is marked it deals 4x damage. You can mark enemy with E. {ManaCost(RayZConstants.QManaCost)}";
    }

    public string GetWExplanation() {
        return $"W has 6 random usages, you can either gain mana point or mark enemy.{ManaCost(RayZConstants.WManaCost)}";
    }

    public string GetEExplanation() {
        return $"Deals some small damage and marks enemy. {ManaCost(RayZConstants.EManaCost)}";
    }

    public string GetRExplanation() {
        return
            "Consumes current mana and resets every cooldown and mana points to its initial state.";
    }

    private string ManaCost(int manaCost) {
        return $"Mana cost: {manaCost}";
    }
}