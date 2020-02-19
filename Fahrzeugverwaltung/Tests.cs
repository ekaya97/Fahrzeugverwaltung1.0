using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Tests
    {
        public static void testStarten()
        {
            //Parkhaus P1 = new Parkhaus("Koeln", 51105, "Westerwaldstr. 99", "DE");
            //Program.parkhaeuser.Add(P1);
            //Parkhaus P69 = new Parkhaus("Koeln", 51105, "Westerwaldstr. 100", "DE");
            //Program.parkhaeuser.Add(P1);
            //Parkhaus P187 = new Parkhaus("Koeln", 51105, "Westerwaldstr. 101", "DE");
            //Program.parkhaeuser.Add(P1);

            //Console.WriteLine(P1.PID);
            //Console.WriteLine(P69.PID);
            //Console.WriteLine(P187.PID);

            //PKW VWK = new PKW("Volkswagen", "Käfer", "K-GS-01", 9999, 1965, 1000, 30, Schadstoffklasse.Normal);
            //Program.fahrzeuge.Add(VWK);
            //P1.fahrzeugEinparken(VWK,100);


            //PKW OPK = new PKW("Opel", "Kadett", "K-GS-02", 12000, 1964, 1600, 60, Schadstoffklasse.Diesel);
            //Program.fahrzeuge.Add(OPK);
            //P1.fahrzeugEinparken(OPK);


            //Motorrad BMR = new Motorrad("BMW", "R1200r", "K-GS-03", 6000, 1999, 1170);
            //Program.fahrzeuge.Add(BMR);
            //P1.fahrzeugEinparken(BMR);

            //LKW MEL = new LKW("Mercedes", "LG 315", "K-GS-04", 23000, 1960, 2, 5.5f);
            //Program.fahrzeuge.Add(MEL);
            //P1.fahrzeugEinparken(MEL);

            Program.init();

            Console.WriteLine(Program.parkhaeuser[0].PID);
            Console.WriteLine("Stellplatznummer: " + Program.parkhaeuser[0].fahrzeugParkplatzFinden(Console.ReadLine()));

            //Test Ausgabe eines bestimmten Fahrzeugs
            Console.WriteLine("Für Fahrzeug Daten Kennzeichen eingeben");
            Console.WriteLine(Program.ausgabeFahrzeugDaten(Console.ReadLine()));

            //Test Ausgabe aller Fahrzeuge
            Console.WriteLine(Program.ausgabeFahrzeugDaten());

            //Test Ausgabe einer bestimmten Steuerschuld
            Console.WriteLine("Für Steuerschulden Kennzeichen eingeben");
            Console.WriteLine(Program.steuerschuldAusgabe(Console.ReadLine()) + " EUR \n");

            //Test Ausgabe aller Steuerschulden
            Console.WriteLine(Program.steuerschuldAusgabe() + " EUR \n");







        }


    }
}
