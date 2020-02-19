using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Program
    {

        public static List<Parkhaus> parkhaeuser = new List<Parkhaus>();
        public static List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
        public static Dictionary<string, string> stellplatzVerzeichnis = new Dictionary<string, string>();


        static void Main(string[] args)
        {
            
            Tests.testStarten();
        }

        public static void init()
        {
            Konfig.deserializeFromJSON();
            Konfig.serializeToJSON(fahrzeuge);
            Konfig.serializeToJSON(parkhaeuser);
            Konfig.serializeToJSON(stellplatzVerzeichnis);
        }

        public static void fahrzeugAnlegen()
        {
            Console.WriteLine("PKW = 1");
            if (Console.ReadLine().ToLower().Contains("P")){

            }
        }


        public static String ausgabeFahrzeugDaten(String Kennzeichen)
        {
            String fahrzeugDaten = "Fahrzeug nicht gefunden!";
            Kennzeichen = ToUpperIgnoreDash(Kennzeichen.Trim());
            for (int i = 0; i < fahrzeuge.Count; i++)
            {
                if (fahrzeuge[i].Kennzeichen.Equals(Kennzeichen.Trim()))
                {
                     fahrzeugDaten = fahrzeuge[i].ToString();
                    return fahrzeugDaten;
                }
            }
            return fahrzeugDaten;

        }

        public static String ausgabeFahrzeugDaten()
        {
            String fahrzeugDaten = "";

            for (int i = 0; i < fahrzeuge.Count; i++)
            {
                fahrzeugDaten += fahrzeuge[i].ToString();
            }
            if (fahrzeugDaten.Equals(""))
            {
                fahrzeugDaten += "Keine Fahrzeuge gefunden!";
            }


            return fahrzeugDaten;
        }

        public static float steuerschuldAusgabe(String Kennzeichen)
        {
            float steuerschuld = 0;
            Kennzeichen = ToUpperIgnoreDash(Kennzeichen.Trim());

            for (int i = 0; i < fahrzeuge.Count; i++)
            {
                if (fahrzeuge[i].Kennzeichen.Equals(Kennzeichen.Trim()))
                {
                    steuerschuld += fahrzeuge[i].steuerschuldBerechnen();
                    return steuerschuld;
                }
            }

            return steuerschuld;
        }

        public static float steuerschuldAusgabe()
        {
            float steuerschuld = 0;

            for (int i = 0; i < fahrzeuge.Count; i++)
            {
                steuerschuld += fahrzeuge[i].steuerschuldBerechnen();
            }

            return steuerschuld;

        }


        public static string ToUpperIgnoreDash(string input)
        {
            string[] words = input.Split('-');

           for(int i = 0; i < words.Length;i++)
            {

                words[i] = words[i].ToUpper();
            }

            return string.Join("-", words);
        }

    }
}
