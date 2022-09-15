using ConsoleApp2;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, user. Please supply your data!");
        Thread.Sleep(2000);
        Console.Clear();

        People.GetData();
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

    private static void MainMenu()
    {
        Console.WriteLine("\nWhat would you like to do?\na - retrieve all saved data\nb - register another user");
        var option = Console.ReadLine();

        if (option.Equals("a"))
        {
            People.PrintAllData();
            MainMenu();
        }
        else
        {
            People.GetData();
        }
    }
}