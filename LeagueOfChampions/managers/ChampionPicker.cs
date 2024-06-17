using LeagueOfChampions.champions.@base;

namespace LeagueOfChampions.managers;

public class ChampionPicker {
    private readonly List<Champion> _champions;
    private readonly SubtitlesPrinter subtitlesPrinter;

    public ChampionPicker(List<Champion> champions, SubtitlesPrinter subtitlesPrinter) {
        _champions = champions;
        this.subtitlesPrinter = subtitlesPrinter;
    }

    public (Champion, Champion) PickChampions() {
        subtitlesPrinter.PrintChampionList(_champions);
        subtitlesPrinter.PrintPlayerToPickNumber(1);
        var champion1 = PickChampion();
        subtitlesPrinter.PrintChosenChampion(champion1.Name);

        subtitlesPrinter.PrintChampionList(_champions);
        subtitlesPrinter.PrintPlayerToPickNumber(2);
        var champion2 = PickChampion();
        subtitlesPrinter.PrintChosenChampion(champion2.Name);

        return (champion1, champion2);
    }

    private Champion PickChampion() {
        Champion? champion;
        do {
            var championName = Console.ReadLine();
            champion = FindChampionByName(championName);
        } while (champion == null);

        _champions.Remove(champion);
        return champion;
    }

    private Champion? FindChampionByName(string? championName) {
        foreach (var champion in _champions) {
            if (championName != null &&
                championName.ToLower().Contains(champion.Name.ToLower())) {
                return champion;
            }
        }

        return null;
    }
}