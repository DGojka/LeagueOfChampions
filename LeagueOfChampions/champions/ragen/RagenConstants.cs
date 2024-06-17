namespace LeagueOfChampions.champions.ragen; 

public static class RagenConstants {
    public const string RAGEN = "Ragen";

    //stats
    public const int MAX_HP = 400;
    public const int ATTACK_DAMAGE = 20;
    public const int ARMOR = 40;
    public const int MAX_MANA = 4;

    //mana costs
    public const int BasicAttackManaCost = 1;
    public const int QManaCost = 2;
    public const int WManaCost = 1;
    public const int EManaCost = 2;
    public const int RManaCost = MAX_MANA;

    //spells
    //Q
    public const int QDamage = ATTACK_DAMAGE * 3;

    //W
    public const int WArmorGain = 5;

    //E
    public const int SingleSpinDamage = 7;
    public const int MinSpinsCount = 0;
    public const int MaxSpinsCount = 13;

    //R
    public const int RDamage = 50;

    //PASSIVE
    public const int MinHpToUsePassive = MAX_HP - 30;
}