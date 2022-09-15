using ConsoleApp2;
using System.Text.RegularExpressions;

class Program
{
    private static List<People> people = new();
    private static string fullname;
    private static string displayName;
    private static string gender;
    private static string title;
    private static int age;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, user. Please supply your data!");
        Thread.Sleep(2000);
        Console.Clear();

        GetData();
    }

    private static void GetData()
    {
        Console.WriteLine("Select your title:\na - Mr\nb - Mrs\nc - Miss\nd - Mx\ne - Sir\nf - Dr");
        var titleOption = Console.ReadLine();
        
        switch (titleOption)
        {
            case "a":
                title = "Mr.";
                break;
            case "b":
                title = "Mrs.";
                break;
            case "c":
                title = "Miss.";
                break;
            case "d":
                title = "Mx.";
                break;
            case "e":
                title = "Sir.";
                break;
            case "f":
                title = "Dr.";
                break;
            default:
                Acknowledge(0);
                break;
        }
        Acknowledge(1);

        Console.Write("What is your full name? ");
        var nameOption = Console.ReadLine();

        if (Regex.IsMatch(nameOption, "^[A-Za-z-]"))
        {
            fullname = nameOption;
        }
        Acknowledge(1);

        Console.Write("How old are you? ");
        var ageOption = Console.ReadLine();

        Acknowledge(int.TryParse(ageOption, out age) ? 1 : 0);

        Console.WriteLine("What is your sex?\na - Male\nb - Female");
        var genderOption = Console.ReadLine();

        switch (genderOption)
        {
            case "a":
                gender = "Male";
                break;
            case "b":
                gender = "Female";
                break;
            default:
                Acknowledge(0);
                break;
        }

        displayName = title + " " + fullname;
        
        People.SaveData(people, displayName, age, gender);
        Acknowledge(2);
    }

    private static void Acknowledge(int option)
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
            people.Remove(people[people.Count]);
            Console.WriteLine("Invalid response! Restarting...");
        }
        Thread.Sleep(500);
    }

    private static void PrintAllData()
    {
        for (int i = 0; i < people.Count; i++)
        {
            Console.WriteLine("------------------------\nUser #" + (i + 1) + "\nName: " + people[i].name + "\nAge: " + people[i].age + "\nGender: " + people[i].gender);
        }
    }

    private static void MainMenu()
    {
        Console.WriteLine("\nWhat would you like to do?\na - retrieve all saved data\nb - register another user");
        var option = Console.ReadLine();

        if (option.Equals("a"))
        {
            PrintAllData();
            MainMenu();
        }
        else
        {
            GetData();
        }
    }
}