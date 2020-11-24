using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace USurvive
{
    public static class DatabaseLoad
    {
        public static void LoadClasses()
        {
            string classFile = Globals.dataDir + "classes.json";

            string[] jsonLines = File.ReadAllLines(classFile);

            foreach (string jsonLine in jsonLines)
            {
                Globals.tempClasses.Add(JsonSerializer.Deserialize<Class>(jsonLine));
            }
        }
    }
}
