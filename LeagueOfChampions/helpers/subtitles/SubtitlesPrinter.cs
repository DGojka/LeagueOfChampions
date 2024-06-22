﻿using LeagueOfChampions.champions;
using LeagueOfChampions.champions.@base;
using LeagueOfChampions.spell;

namespace LeagueOfChampions;

using System;

public class SubtitlesPrinter {
    public void PrintEnter(int enterCount) {
        for (int i = 0; i < enterCount; i++) {
            Println(" ");
        }
    }

    //GAME
    public void PrintRoundCount(int roundCount) {
        Println("ROUND: " + roundCount + ". FIGHT!");
    }

    public void PrintTurn(string championName) {
        Println("================== " + championName + "'s turn! ==================");
    }

    public void PrintHp(Champion champion) {
        Println(champion.GetType().Name + ": " + champion.CurrentHp + " hp");
    }

    public void PrintWinner(string championName) {
        Println(championName + " has won!");
    }

    public void PrintManaPoints(int manaPoints) {
        Println("Remaining mana points: " + manaPoints);
    }


    //PRE-game
    public void PrintChampionList(List<Champion> champions) {
        Println("List of the Champions: " + string.Join(", ", champions));
    }

    public void PrintPlayerToPickNumber(int playerNumber) {
        Print("Player " + playerNumber + ": ");
    }

    public void PrintStartBattle() {
        Println("The battle will begin in 2 seconds!");
    }

    public void PrintChosenChampion(string championName) {
        Console.WriteLine("You've chosen " + championName);
    }

    public void AskForChampionPick() {
        Println("Pick a champion by typing its name!");
    }

    //CHAMPION SECTION
    public void SpellOnCooldown() {
        Println("Your spell is on cooldown or you might have not enough mana points! Wait for the next round.");
    }

    public void DamageTaken(string victimName, int damageTaken) {
        Println(victimName + " has suffered " + damageTaken + " damage. ");
    }

    //RAGEN
    public void RagenPrintPassive(int regeneratedHp) {
        Println("Perseverance: Ragen regenerated " + regeneratedHp + "HP.");
    }

    public void RagenPrintSpinsCount(int spins) {
        Println("Ragen spun " + spins + " times.");
    }

    //RayZ
    public void RayZPrintPassive(int gainedDamage) {
        Console.WriteLine(
            $"Arcane Mastery: RayZ reads the ancient scrolls gaining {gainedDamage} Attack damage.");
    }

    public void EnemyMarked() {
        Console.WriteLine("RayZ: ENEMY IS MARKED. Your next Q will deal bonus damage.");
    }

    public void RayZGainedArmor() {
        Console.WriteLine($"RayZ: gained {RayZConstants.WArmorGain} Armor ");
    }

    public void RayZResetECooldown() {
        Console.WriteLine("RayZ: E COOLDOWN HAS BEEN RESET!");
    }

    public void RayZGainsManaPoint() {
        Console.WriteLine("RayZ: Gained additional Action Point for this round.");
    }

    public void RayZGainsAd() {
        Console.WriteLine($"RayZ: gained {RayZConstants.WDamageGain} AD.");
    }

    public void RayZBurnedScroll() {
        Console.WriteLine("RayZ: The scroll has burned out. Nothing happens.");
    }

    //OTHERS
    private void Print(string text) {
        Console.Write(text);
    }

    private void Println(string text) {
        Console.WriteLine(text);
    }

    public void PrintChampionInfo(SpellsExplanation spellsExplanation) {
        Println("================== CHAMPION INFO ==================");
        Println($"• Type 'Q' for: {spellsExplanation.GetQExplanation()} ");
        Println($"• Type 'W' for: {spellsExplanation.GetWExplanation()} ");
        Println($"• Type 'E' for: {spellsExplanation.GetEExplanation()} ");
        Println($"• Type 'R' for: {spellsExplanation.GetRExplanation()} ");
        Println("• Type 'T' for: basic attack. Mana cost: 1 ");
        Println("===================================================");
    }

    public void PrintWrongKey() {
        Println("Wrong key! Try again");
    }

    public void PrintTypeHelp() {
        Println("Type 'help' for more information.");
    }
}