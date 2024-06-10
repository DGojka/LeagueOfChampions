using LeagueOfChampions.champions.@base;

namespace LeagueOfChampions;

public class ChampionPicker {
    private readonly List<Champion> _champions;

    public ChampionPicker(List<Champion> champions) {
        _champions = champions;
    }

    public Champion PickChampion() {
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
                championName.ToLower().Equals(champion.GetName().ToLower())) {
                return champion;
            }
        }

        return null;
    }
}