using LeagueOfChampions.champions;
using LeagueOfChampions.champions.@base;

namespace LeagueOfChampions;

public class ChampionCreator {
    public static List<Champion> CreateChampions(SubtitlesPrinter subtitlesPrinter) {
        List<Champion> championsList = new List<Champion> {
            new Dummy(subtitlesPrinter)
        };

        return championsList;
    }
}