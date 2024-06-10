namespace LeagueOfChampions; 

public class MathHelper
{
    public static int RandomInt(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    public static bool RandomBoolean()
    {
        return RandomInt(1, 3) == 1;
    }
}