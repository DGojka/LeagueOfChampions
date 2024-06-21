﻿using LeagueOfChampions.champions;
using LeagueOfChampions.champions.@base;
using LeagueOfChampions.champions.ragen;

namespace LeagueOfChampions.managers;

public static class ChampionCreator {
    public static List<Champion> CreateChampions(SubtitlesPrinter subtitlesPrinter) {
        var championsList = new List<Champion> {
            new Dummy(subtitlesPrinter),
            new Ragen(subtitlesPrinter),
            new RayZ(subtitlesPrinter),
        };

        return championsList;
    }
}