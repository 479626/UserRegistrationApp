using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleApp2
{
    internal class People
    {
        private static List<People> people = new();
        private static string userFullname, userDisplayName, userGender, userTitle;
        private static int userAge;
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.json");

        public string name { get; set; }
        public int age { get; set; }   
        public string gender { get; set; }

        private static void SaveData(List<People> people, string unsavedName, int unsaveduserAge, string unsaveduserGender)
        {
            people.Add(new People() { 
                name = unsavedName, 
                age = unsaveduserAge, 
                gender = unsaveduserGender 
            });
        }

        public static void SaveToJson()
        {
            if (File.Exists(filePath)) File.Delete(filePath);
            string json = JsonSerializer.Serialize(people);
            string savePath = filePath;
            File.WriteAllText(savePath, json);
        }

        public static void LoadFromJson()
        {
            if (File.Exists(filePath))
            {
                string jsonFile = File.ReadAllText(filePath);
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);

                foreach (Dictionary entry in dictionary)
                {
                    people.Add(entry);
                }
                Console.Clear();
                Console.WriteLine("Loading your data...\n");
                Thread.Sleep(500);
                PrintAllData();
            }
            else
            {
                Console.WriteLine("Could not find 'people.json' file! Please move your file to the directory: " + AppDomain.CurrentDomain.BaseDirectory.ToString());
                MainMenu();
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\nWhat would you like to do?\na - retrieve all saved data\nb - register a user\nc - save your data to json\nd - load data from json");
            var option = Console.ReadLine();

            switch (option)
            {
                case "a":
                    PrintAllData();
                    MainMenu();
                    break;
                case "b":
                    GetData();
                    break;
                case "c":
                    SaveToJson();
                    break;
                case "d":
                    //LoadFromJson();
                    break;
            }
        }

        public static void GetData()
        {
            Console.WriteLine("Select your userTitle:\na - Mr\nb - Mrs\nc - Miss\nd - Mx\ne - Sir\nf - Dr");
            var userTitleOption = Console.ReadLine();

            switch (userTitleOption)
            {
                case "a":
                    userTitle = "Mr.";
                    break;
                case "b":
                    userTitle = "Mrs.";
                    break;
                case "c":
                    userTitle = "Miss.";
                    break;
                case "d":
                    userTitle = "Mx.";
                    break;
                case "e":
                    userTitle = "Sir.";
                    break;
                case "f":
                    userTitle = "Dr.";
                    break;
                default:
                    Program.Acknowledge(0);
                    break;
            }
            Program.Acknowledge(1);

            Console.Write("What is your full name? ");
            var nameOption = Console.ReadLine();

            if (Regex.IsMatch(nameOption, "^[A-Za-z-]"))
            {
                userFullname = nameOption;
            }
            Program.Acknowledge(1);

            Console.Write("How old are you? ");
            var userAgeOption = Console.ReadLine();

            Program.Acknowledge(int.TryParse(userAgeOption, out userAge) ? 1 : 0);

            Console.WriteLine("What is your sex?\na - Male\nb - Female");
            var userGenderOption = Console.ReadLine();

            switch (userGenderOption)
            {
                case "a":
                    userGender = "Male";
                    break;
                case "b":
                    userGender = "Female";
                    break;
                default:
                    Program.Acknowledge(0);
                    break;
            }

            userDisplayName = userTitle + " " + userFullname;

            SaveData(people, userDisplayName, userAge, userGender);
            Program.Acknowledge(2);
        }
        public static void PrintAllData()
        {
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine("------------------------\nUser #" + (i + 1) + "\nName: " + people[i].name + "\nAge: " + people[i].age + "\nGender: " + people[i].gender);
            }
        }
    }
}
