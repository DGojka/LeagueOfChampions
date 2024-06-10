namespace LeagueOfChampions; 
using System;

public static class KeyboardManager
{
    public static KeyType GetKey()
    {
        string? key = Console.ReadLine();
        return key?.ToUpper() switch
        {
            "T" => KeyType.T,
            "Q" => KeyType.Q,
            "W" => KeyType.W,
            "E" => KeyType.E,
            "R" => KeyType.R,
            _ => KeyType.UNKNOWN,
        };
    }
}

public enum KeyType
{
    T,
    Q,
    W,
    E,
    R,
    UNKNOWN
}
