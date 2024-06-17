using LeagueOfChampions.managers;

namespace LeagueOfChampions;

public class MainClass {
    public static void Main() {
        var subtitlesPrinter = new SubtitlesPrinter();
        var champions = ChampionCreator.CreateChampions(subtitlesPrinter);
        var pickingHandler = new ChampionPicker(champions, subtitlesPrinter);
        var chosenChampions = pickingHandler.PickChampions();
        
        var game = new Game(chosenChampions.Item1, chosenChampions.Item2, subtitlesPrinter);
        game.Start();
    }
}