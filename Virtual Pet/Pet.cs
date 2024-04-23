abstract class Pet
{
    public int Hunger { get; set; }
    public int Thirst { get; set; }

    public void ReduceState()
    {
        Random rndReduse = new();

        Hunger -= rndReduse.Next(8, 20);
        Thirst -= rndReduse.Next(8, 20);
    }
}

class Cat : Pet
{
    public Cat()
    {
        Hunger = 40;
        Thirst = 30;
    }
}

class Dog : Pet
{
    public Dog()
    {
        Hunger = 50;
        Thirst = 30;
    }
}