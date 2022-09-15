using ConsoleApp2;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, user.");
        Thread.Sleep(500);
        Console.Clear();

        People.MainMenu();
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
            People.MainMenu();
        } 
        else
        {
            Console.WriteLine("Invalid response! Restarting...");
        }
        Thread.Sleep(500);
    }
}