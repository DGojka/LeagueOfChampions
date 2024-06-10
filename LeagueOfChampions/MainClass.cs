using LeagueOfChampions.managers;

namespace LeagueOfChampions;

public class MainClass {
    public static void Main() {
        var subtitlesPrinter = new SubtitlesPrinter();
        var champions = ChampionCreator.CreateChampions(subtitlesPrinter);
        var pickingHandler = new ChampionPicker(champions);

        // Picking Champions
        subtitlesPrinter.PrintChampionList(champions);
        subtitlesPrinter.PrintPlayerToPickNumber(1);
        var champion1 = pickingHandler.PickChampion();

        subtitlesPrinter.PrintChampionList(champions);
        subtitlesPrinter.PrintPlayerToPickNumber(2);
        var champion2 = pickingHandler.PickChampion();

        subtitlesPrinter.PrintStartBattle();

        var game = new Game(champion1, champion2, subtitlesPrinter);
        game.Start();
    }
}