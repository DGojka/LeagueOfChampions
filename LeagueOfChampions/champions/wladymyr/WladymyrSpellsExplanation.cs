using LeagueOfChampions.spell;

namespace LeagueOfChampions.champions;

public class WladymyrSpellsExplanation : SpellsExplanation {
    public string GetQExplanation() {
        return
            $"Wladymyr uses his blood to deal damage and heal himself. {WladymyrConstants.QManaCost}";
    }

    public string GetWExplanation() {
        return
            $"Wladymyr uses his blood to gain Attack Damage. The less hp he has, the more damage he gains {WladymyrConstants.WManaCost}";
    }

    public string GetEExplanation() {
        return
            $"Wladymyr exchanges his Attack Damage to gain hp. {WladymyrConstants.EManaCost}";
    }

    public string GetRExplanation() {
        return
            $"Wladymyr exchange massive portion of ad in exchange of massive portion of Hp{WladymyrConstants.RManaCost}";
    }
}