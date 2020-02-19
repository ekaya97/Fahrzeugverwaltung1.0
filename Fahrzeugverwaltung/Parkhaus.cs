using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    public enum StellplatzArt
    {
        PKW = 1,
        Motorrad = 2,
        LKW = 3,
    }
    class Stellplatz
    {
        public StellplatzArt Art { get; set; }
            // 1 = PKW; 2 = LKW; 3 = Motorrad
        public int Nummer { get; set; }
        public Fahrzeug Fahrzeug { get; set; }

        public Stellplatz(StellplatzArt _art, int _nummer, Fahrzeug _fahrzeug)
        {
            Art = _art;
            Nummer = _nummer;
            Fahrzeug = _fahrzeug;
        }

    }

    class Parkhaus
    {

        public String Ort { get; set; }
        public int PLZ { get; set; }
        public String Strasse { get; set; }
        public String Land { get; set; }
        public String PID { get; set; }
        public List<Stellplatz> Stellplatzliste { get; set; }

        public static int IDZaehler = 1;


        public Parkhaus(String _ort, int _plz, String _strasse, String _land)
        {
            Ort = _ort;
            PLZ = _plz;
            Strasse = _strasse;
            Land = _land;
            PID = "P" + IDZaehler++;
            stellplatzListeErstellen();
        }


        public void stellplatzListeErstellen()
        {

            this.Stellplatzliste = new List<Stellplatz>();

            for (int i = 0; i < 100; i++)
            {
                Stellplatz PKWPlatz = new Stellplatz(StellplatzArt.PKW, i+100, null);
                Stellplatzliste.Add(PKWPlatz);
            }
            for (int i = 100; i < 200; i++)
            {
                Stellplatz MotorradPlatz = new Stellplatz(StellplatzArt.Motorrad, i+100, null);
                Stellplatzliste.Add(MotorradPlatz);
            }
            for (int i = 200; i < 300; i++)
            {
                Stellplatz LKWPlatz = new Stellplatz(StellplatzArt.LKW, i+100, null);
                Stellplatzliste.Add(LKWPlatz);
            }
        }

        public Boolean stellplatzFrei(int nummer)
        {
            if(this.Stellplatzliste[nummer-100].Fahrzeug != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean fahrzeugAusparken(Fahrzeug f)
        {
            String[] parkplatzArr = Program.fahrzeugParkplatzFinden(f.Kennzeichen).Split('-');

            if (parkplatzArr[0] != PID)
            {
                Console.WriteLine("Fahrzeug ist nicht in diesem Parkhaus eingeparkt!");
                return false;
            }
            else
            {
                int parkplatzNr = Int16.Parse(parkplatzArr[1]);

                Program.stellplatzVerzeichnis.Remove(Stellplatzliste[parkplatzNr - 100].Fahrzeug.Kennzeichen);
                this.Stellplatzliste[parkplatzNr - 100].Fahrzeug = null;
                Console.WriteLine("Fahrzeug ausgeparkt!");
                return true;
            }
        }


        // CHECKEN OB DAS KLAPPT
        public Boolean fahrzeugEinparken(Fahrzeug f)
        {
            for (int i = 0; i < Stellplatzliste.Count; i++)
            {
                if (stellplatzFrei(i+100) && f.GetType().Name == Stellplatzliste[i].Art.ToString())
                {
                    this.Stellplatzliste[i].Fahrzeug = f;
                    Program.stellplatzVerzeichnis.Add(Stellplatzliste[i].Fahrzeug.Kennzeichen, this.PID + "-" + Stellplatzliste[i].Nummer);
                    return true;
                }
            }
            return false;
        }

        public Boolean fahrzeugEinparken(Fahrzeug f, int stellplatznummer)
        {

            if (f.GetType().Name != Stellplatzliste[stellplatznummer - 100].Art.ToString())
            {
                Console.WriteLine("Stellplatz ist für dieses Fahrzeug nicht geeignet!");
                Console.WriteLine("Bitte einen anderen Stellplatz wählen!");
                return false;
            }
            else if(stellplatzFrei(stellplatznummer))
            {
                this.Stellplatzliste[stellplatznummer-100].Fahrzeug = f;
                Program.stellplatzVerzeichnis.Add(Stellplatzliste[stellplatznummer-100].Fahrzeug.Kennzeichen, this.PID + "-" + stellplatznummer);
                return true;
            }
            else
            {
                Console.WriteLine("Stellplatz ist bereits vom Fahrzeug mit dem Kennzeichen "+ this.Stellplatzliste[stellplatznummer - 100].Fahrzeug.Kennzeichen+ " belegt.");
                return false;
            }
        }
    }
}
