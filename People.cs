using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class People
    {
        private static List<People> people = new();
        private static string userFullname, userDisplayName, userGender, userTitle;
        private static int userAge;

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
            JsonSerializer.SerializeList(people, "people.json");
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
