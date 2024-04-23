class User
{
    public void ProvideEat(Pet pet)
        => (Bug.Eat, pet.Hunger) = ExecuteValidation(Bug.Eat, pet.Hunger, Menu.MaxHunger);

    public void ProvideWater(Pet pet)
        => (Bug.Water, pet.Thirst) = ExecuteValidation(Bug.Water, pet.Thirst, Menu.MaxThirst);

    private (int updatedFeed, int updatedCondition) ExecuteValidation(int feed, int condition, int maxCondition)
    {
        int feedCount = int.Parse(Console.ReadLine());

        if (feedCount >= 0 && feedCount <= feed)
        {
            if (feedCount + condition > maxCondition)
            {
                int remainingFeed = feedCount + condition - maxCondition;

                feed -= feedCount - remainingFeed;
                condition += feedCount - remainingFeed;
            }

            else
            {
                feed -= feedCount;
                condition += feedCount;
            }
        }

        return (feed, condition);
    }

    public void BuyingFeed()
       => ExecuteValidation(ref Bug.Eat);

    public void BuyingWater()
       => ExecuteValidation(ref Bug.Water);

    private int ExecuteValidation(ref int feed)
    {
        int feedCount = int.Parse(Console.ReadLine());

        if (feedCount >= 0 && feedCount <= Bug.Money)
        {
            Bug.Money -= feedCount;
            feed += feedCount;
        }

        return feed;
    }
}