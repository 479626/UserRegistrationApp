using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class People
    {
        public string name { get; set; }
        public int age { get; set; }   
        public string gender { get; set; }

        public static void SaveData(List<People> people, string unsavedName, int unsavedAge, string unsavedGender)
        {
            people.Add(new People() { name = unsavedName, age = unsavedAge, gender = unsavedGender });
        }
    }
}
