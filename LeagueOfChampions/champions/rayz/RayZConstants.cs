﻿namespace LeagueOfChampions.champions;

public class RayZConstants {
    public const string NAME = "RayZ";

    //stats
    public const int MAX_HP = 40;
    public const int ATTACK_DAMAGE = 100;
    public const int ARMOR = 20;
    public const int MAX_MANA = 5;

    //mana costs
    public const int BasicAttackManaCost = 1;
    public const int QManaCost = 2;
    public const int WManaCost = 1;
    public const int EManaCost = 1;

    //spells
    //Q
    public const int QBaseDamage = ATTACK_DAMAGE * 2;
    public const int QMarkedDamage= ATTACK_DAMAGE * 4;

    //W
    public const int WDamageGain = 5;
    public const int WArmorGain = 2;
    
    
    //E
    public const int EDamage = (int)(ATTACK_DAMAGE * 0.6);
}