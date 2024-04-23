using System.Diagnostics;
using System;

class Menu
{
    private Pet _pet;
    private User _user = new User();

    public int Day { get; private set; }
    public static int MaxHunger { get; private set; }
    public static int MaxThirst { get; private set; }

    public Pet SelectPet()
    {
        while (_pet == null)
        {
            Console.CursorLeft = 40;
            Console.WriteLine("| Select Pet |");

            Console.WriteLine("'1' - Cat, '2' - Dog");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _pet = new Cat();
                    break;

                case '2':
                    _pet = new Dog();
                    break;

                default:
                    Console.Clear();
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

        IfPetDies();
    }

    private void DrawMenuGraphics()
    {
        Console.CursorLeft = 40;
        Console.WriteLine("| Virtual Pet |");

        Console.CursorTop = 15;
        Console.WriteLine($"Hunger - {_pet.Hunger}/{MaxHunger}\nThirst - {_pet.Thirst}/{MaxThirst}\n\nDay - {Day}\nMoney - {Bug.Money}\nFeed - {Bug.Eat}\nWater - {Bug.Water}");
        
        Console.WriteLine("\n'1' - New Day\n'2' - Give Eat\n'3' - Give Water\n'4' - Buy Feed");

        Console.CursorTop = 1;
        Console.Write("> ");
    }

    private void MoveToNextDay()
    {
        Day++;

        _pet.ReduceState();

        Bug.UpdateDailyMoney();

        Bug.UpdateDailyFeed(ref Bug.Eat);
        Bug.UpdateDailyFeed(ref Bug.Water);
    }

    private void IfPetDies()
    {
        Console.Clear();
        Console.WriteLine("I`m sorry you... Your pet dead. Press F for respect");

        StartFVideo();
    }

    private void StartFVideo()
    {
        string urlGiveRespect = "https://youtu.be/TtMzTGfs-fc?si=Frbu6ZSA7XSJ0pvZ";
        string urlNotRespect = "https://youtu.be/R52gjhsRQO8?si=1L1vzdEd69nr4mWQ";

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.F:
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start {urlGiveRespect}",
                    UseShellExecute = true
                });
                break;

            default:
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start {urlNotRespect}",
                    UseShellExecute = true
                });
                break;
        }
    }
}