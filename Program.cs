using ConsoleApp2;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, user.");
        Thread.Sleep(500);
        Console.Clear();

        MainMenu();
    }

    public static void MainMenu()
    {
        Console.WriteLine("\nWhat would you like to do?\na - retrieve all saved data\nb - register a user\nc - save your data to json\nd - load data from json");
        var option = Console.ReadLine();

        switch (option)
        {
            case "a":
                People.PrintAllData();
                MainMenu();
                break;
            case "b":
                People.GetData();
                break;
            case "c":
                People.SaveToJson();
                break;
            case "d":
                //JsonSerializer.LoadFromJson();
                break;
        }
    }

    public static void Acknowledge(int option)
    {
        Console.Clear();
        if (option.Equals(1))
        {
            Console.WriteLine("Your entry has been recorded");
        } 
        else if (option.Equals(2))
        {
            Console.WriteLine("Thank you! Registration complete.");
            MainMenu();
        } 
        else
        {
            Console.WriteLine("Invalid response! Restarting...");
        }
        Thread.Sleep(500);
    }
}