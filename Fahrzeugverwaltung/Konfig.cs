using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fahrzeugverwaltung
{
    class Konfig
    {
        public static void serializeToJSON(List<Fahrzeug> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\config\fahrzeuge.txt", json);
        }
        public static void serializeToJSON(List<Parkhaus> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\config\parkhaeuser.txt", json);
        }
        public static void serializeToJSON(Dictionary<string, string> dict)
        {
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            System.IO.File.WriteAllText(@"..\..\config\stellplatzverzeichnis.txt", json);
        }

        public static void deserializeFromJSON()
        {
            string jsonF = System.IO.File.ReadAllText(@"..\..\config\fahrzeuge.txt");
            Program.fahrzeuge = JsonConvert.DeserializeObject<List<Fahrzeug>>(jsonF);

            string jsonP = System.IO.File.ReadAllText(@"..\..\config\parkhaeuser.txt");
            Program.parkhaeuser = JsonConvert.DeserializeObject<List<Parkhaus>>(jsonP);

            string jsonD = System.IO.File.ReadAllText(@"..\..\config\stellplatzverzeichnis.txt");
            Program.stellplatzVerzeichnis = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonD); 

        }
    }
}
