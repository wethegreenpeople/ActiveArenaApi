public static class RandomGenerationUtils
{
    public static Random Random = new Random();

    public static bool HappensWithChance(short chanceOfHappening)
    {
        return Random.Next(0, 101) <= chanceOfHappening;
    }
}