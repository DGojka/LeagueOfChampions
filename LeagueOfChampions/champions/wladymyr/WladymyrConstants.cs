namespace LeagueOfChampions.champions;

public class WladymyrConstants {
    public const string NAME = "Wladymyr";

    //stats
    public const int MAX_HP = 60;
    public const int ATTACK_DAMAGE = 40;
    public const int ARMOR = 20;
    public const int MAX_MANA = 4;

    //mana costs
    public const int BasicAttackManaCost = 1;
    public const int QManaCost = 2;
    public const int WManaCost = 1;
    public const int EManaCost = 1;
    public const int RManaCost = MAX_MANA;

    //W
    public const int W1LevelAdGain = 1;
    public const int W2LevelAdGain = 3;
    public const int W3LevelAdGain = 5;
    public const int W4LevelAdGain = 9;
    public const int W5LevelAdGain = 13;
    public const int W6LevelAdGain = 20;

    public const double W6LevelHpThreshold = 0.2;
    public const double W5LevelHpThreshold = 0.35;
    public const double W4LevelHpThreshold = 0.5;
    public const double W3LevelHpThreshold = 0.7;
    public const double W2LevelHpThreshold = 0.85;
    
    //E
    public const int SpellEExchangedAd = 5;
    
    //PASSIVE
    public const int PassiveLostBlood = 5;
    public const int PassiveGainedAd = 10;
}