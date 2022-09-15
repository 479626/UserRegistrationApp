using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class JsonSerializer
    {
        public static void SerializeList<T>(List<T> data, string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(filePath)) File.Delete(filePath);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            string savePath = filePath;
            File.WriteAllText(savePath, json);
        }
    }
}
