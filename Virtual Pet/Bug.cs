static class Bug
{
    public static int Money { get; set; }

    public static int Eat;
    public static int Water;

    public static void UpdateDailyMoney()
    {
        Random rndMoney = new Random();
        Money += rndMoney.Next(5, 10);
    }

    public static int UpdateDailyFeed(ref int feed)
    {
        Random rndFeed = new Random();
        return feed += rndFeed.Next(5, 10);
    }
}