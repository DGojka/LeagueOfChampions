using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions.ragen;

public class RagenSpellExplanation : SpellsExplanation {
    public string GetQExplanation() {
        return $"Ragen attacks and deals 3x damage. Mana cost: {RagenConstants.QManaCost}";
    }

    public string GetWExplanation() {
        return
            $"Ragen gains {RagenConstants.WArmorGain} armor for the rest of the combat. Mana cost: {RagenConstants.WManaCost}";
    }

    public string GetEExplanation() {
        return
            $"Ragen spins with his sword {RagenConstants.MinSpinsCount}-{RagenConstants.MaxSpinsCount} times dealing damage for each spin." +
            $" Spell has no cooldown. Mana cost: {RagenConstants.EManaCost}";
    }

    public string GetRExplanation() {
        return
            $"Ragen pierces the opponent's armor with his sword and inflicts damage based on target's missing hp. " +
            $"Mana cost: {RagenConstants.RManaCost}";
    }
}