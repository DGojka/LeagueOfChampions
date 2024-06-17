using LeagueOfChampions.champions.@base;

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

    public void PrintActionPoints(int actionPoints) {
        Println("Remaining action points: " + actionPoints);
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
        Println("Your spell is on cooldown! Wait for the next round.");
    }

    public void DamageTaken(string victimName, int damageTaken) {
        Println(victimName + " has suffered " + damageTaken + " damage. ");
    }

    //GAREN
    public void RagenPrintPassive(int regeneratedHp) {
        Println("Perseverance: Garen regenerated " + regeneratedHp + "HP.");
    }

    public void RagenPrintSpinsCount(int spins) {
        Println("Ragen spun " + spins + " times.");
    }

    //OTHERS
    private void Print(string text) {
        Console.Write(text);
    }

    private void Println(string text) {
        Console.WriteLine(text);
    }
}
