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

    public static void UpdateDailyFeed(int feed)
    {
        Random rndFeed = new Random();
        feed += rndFeed.Next(5, 10);
    }
}