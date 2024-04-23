class Menu
{
    private Pet _pet;
    private User _user = new User();

    public int Day { get; private set; }
    public static int MaxHunger { get; private set; }
    public static int MaxThirst { get; private set; }

    public Pet SelectPet()
    {
        Console.CursorVisible = false;

        ConsoleKey keyMenu;

        while ((keyMenu = Console.ReadKey().Key) != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("| Choosing a Pet |");

            switch (keyMenu)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine(">Cat\n Dog");
                    _pet = new Cat();
                    break;

                case ConsoleKey.DownArrow:
                    Console.WriteLine(" Cat\n>Dog");
                    _pet = new Dog();
                    break;
            }
        }

        MaxHunger = _pet.Hunger;
        MaxThirst = _pet.Thirst;

        Console.Clear();

        return _pet;
    }

    

    public void PrintMenu()
    {
        while (_pet.Hunger > 0 && _pet.Thirst > 0)
        {
            DrawMenuGraphics();

            switch (Console.ReadKey().KeyChar)
            {
                //Новый день
                case '1':
                    MoveToNextDay();
                    break;

                //Покормить питомца
                case '2':
                    Console.Write("\nHow much food to give > ");
                    _user.ProvideEat(_pet);
                    break;

                //Напоить питомца
                case '3':
                    Console.Write("\nHow much water to give > ");
                    _user.ProvideWater(_pet);
                    break;

                //Купить корм
                case '4':
                    Console.WriteLine("\n'1' - Buy feed, '2' - Buy water");

                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Write("\nHow much you want to buy > ");
                            _user.BuyingFeed();
                            break;

                        case '2':
                            Console.Write("\nHow much you want to buy > ");
                            _user.BuyingWater();
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;   
            }
            Console.Clear();
        }
        
    }

    private void DrawMenuGraphics()
    {
        Console.CursorLeft = 40;
        Console.WriteLine("| Virtual Pet |");

        Console.CursorTop = 15;
        Console.WriteLine($"Hunger - {_pet.Hunger}/{MaxHunger}\nThirst - {_pet.Thirst}/{MaxThirst}\n\nDay - {Day}\nMoney - {Bug.Money}\nFeed - {Bug.Eat}\nWater - {Bug.Water}");

        Console.CursorTop = 1;
        Console.Write("> ");
    }

    private void MoveToNextDay()
    {
        Day++;

        _pet.ReduceState();

        Bug.UpdateDailyMoney();

        Bug.UpdateDailyFeed(Bug.Eat);
        Bug.UpdateDailyFeed(Bug.Water); 
    }
}