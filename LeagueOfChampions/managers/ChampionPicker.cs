using LeagueOfChampions.champions.@base;

namespace LeagueOfChampions;

public class ChampionPicker {
    private readonly List<Champion> champions;
    private readonly SubtitlesPrinter subtitlesPrinter;
    private const string GAREN = "Garen";
    private const string RENGAR = "Rengar";
    private const string RYZE = "Ryze";
    private const string VLADIMIR = "Vladimir";
    private const string UDYR = "Udyr";

    public ChampionPicker(List<Champion> champions, SubtitlesPrinter subtitlesPrinter) {
        this.champions = champions;
        this.subtitlesPrinter = subtitlesPrinter;
    }

    public Champion PickChampion() {
        string? championName = Console.ReadLine();
        Champion champion = FindChampionByName(championName);
    //    champions.Remove(champion);
        return champion;
    }

    private Champion FindChampionByName(string? championName) {
        foreach (Champion champion in champions) {
            if (championName.Equals(champion.GetName())) {
                return champion;
            }
        }

        return null;
    }
}