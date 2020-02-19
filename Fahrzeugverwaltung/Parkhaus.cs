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

        public static int IDZaehler = 1;
        public List<Stellplatz> _stellplatzListe { get; set; }


        public Parkhaus(String _ort, int _plz, String _strasse, String _land)
        {
            Ort = _ort;
            PLZ = _plz;
            Strasse = _strasse;
            Land = _land;
            PID = "P" + IDZaehler++;
            _stellplatzListe = stellplatzListeErstellen();
        }

        public List<Stellplatz> stellplatzListeErstellen()
        {
            List<Stellplatz> _stellplatzListeTemp = new List<Stellplatz>();

            for (int i = 0; i < 100; i++)
            {
                Stellplatz PKWPlatz = new Stellplatz(StellplatzArt.PKW, i+100, null);
                _stellplatzListeTemp.Add(PKWPlatz);
            }
            for (int i = 100; i < 200; i++)
            {
                Stellplatz MotorradPlatz = new Stellplatz(StellplatzArt.Motorrad, i+100, null);
                _stellplatzListeTemp.Add(MotorradPlatz);
            }
            for (int i = 200; i < 300; i++)
            {
                Stellplatz LKWPlatz = new Stellplatz(StellplatzArt.LKW, i+100, null);
                _stellplatzListeTemp.Add(LKWPlatz);
            }
            return _stellplatzListeTemp;
        }

        public Boolean stellplatzFrei(int nummer)
        {
            if(this._stellplatzListe[nummer].Fahrzeug != null)
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
            String[] parkplatzArr = fahrzeugParkplatzFinden(f.Kennzeichen).Split('-');

            if (parkplatzArr[0] != PID)
            {
                Console.WriteLine("Fahrzeug ist nicht in diesem Parkhaus eingeparkt!");
                return false;
            }
 
            int parkplatzNr = Int16.Parse(parkplatzArr[1]);
            if(stellplatzFrei(parkplatzNr-100))
            {
                Program.stellplatzVerzeichnis.Remove(_stellplatzListe[parkplatzNr - 100].Fahrzeug.Kennzeichen);
                this._stellplatzListe[parkplatzNr - 100].Fahrzeug = null;
                Console.WriteLine("Fahrzeug ausgeparkt!");
                return true;
            }
            Console.WriteLine("Es ist ein unbekannter Fehler aufgetaucht. Bitte später nochmal versuchen.");
            return false;

            /*

                        switch (f)
                        {
                            case PKW p:
                                for (int i = 0; i < 100; i++)
                                {
                                    if (this._stellplatzListe[i].Fahrzeug == f)
                                    {
                                        this._stellplatzListe[i].Fahrzeug = null;
                                        stellplatzVerzeichnis.Remove(_stellplatzListe[i].Fahrzeug.Kennzeichen);
                                        return true;
                                    }
                                }
                                return false;
                            case Motorrad m:
                                for (int i = 100; i < 200; i++)
                                {
                                    if (this._stellplatzListe[i].Fahrzeug == f)
                                    {
                                        this._stellplatzListe[i].Fahrzeug = null;
                                        stellplatzVerzeichnis.Remove(_stellplatzListe[i].Fahrzeug.Kennzeichen);
                                        return true;
                                    }
                                }
                                return false;
                            case LKW l:

                                for (int i = 200; i < 300; i++)
                                {
                                    if (this._stellplatzListe[i].Fahrzeug == f)
                                    {

                                        this._stellplatzListe[i].Fahrzeug = null;
                                        stellplatzVerzeichnis.Remove(_stellplatzListe[i].Fahrzeug.Kennzeichen);
                                        return true;
                                    }
                                }
                                return false;
                            default:
                                return false;
                        }
                        */
        }


        // CHECKEN OB DAS KLAPPT
        public Boolean fahrzeugEinparken(Fahrzeug f)
        {
            switch (f)
            {
                case PKW p:
                    for (int i = 0; i < 100; i++)
                    {
                        if (stellplatzFrei(i))
                        {
                            this._stellplatzListe[i].Fahrzeug = p;
                            Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
                            return true;
                        }
                    }
                    return false;

                case Motorrad m:
                    for (int i = 100; i < 200; i++)
                    {
                        if (stellplatzFrei(i))
                        {
                            this._stellplatzListe[i].Fahrzeug = m;
                            Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
                            return true;
                        }
                    }

                    return false;
                case LKW l:

                    for (int i = 200; i < 300; i++)
                    {
                        if (stellplatzFrei(i))
                        {
                            this._stellplatzListe[i].Fahrzeug = l;
                            Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
                            return true;
                        }
                    }
                    return false;
                default:
                    return false;
            }
        }

        public Boolean fahrzeugEinparken(Fahrzeug f, int stellplatznummer)
        {

            if (f.GetType().Name != _stellplatzListe[stellplatznummer - 100].Art.ToString())
            {
                Console.WriteLine("Stellplatz ist für dieses Fahrzeug nicht geeignet!");
                Console.WriteLine("Bitte einen anderen Stellplatz wählen!");
                return false;
            }
            else
            {
                this._stellplatzListe[stellplatznummer-100].Fahrzeug = f;
                Program.stellplatzVerzeichnis.Add(_stellplatzListe[stellplatznummer-100].Fahrzeug.Kennzeichen, this.PID + "-" + stellplatznummer);
                return true;
            }

            //switch (f)
            //{
            //    case PKW p:
                    
            //        for (int i = 0; i < 100; i++)
            //        {
            //            if (this._stellplatzListe[i].Fahrzeug == null)
            //            {
            //                this._stellplatzListe[i].Fahrzeug = p;
            //                Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
            //                return true;
            //            }
            //        }
            //        return false;

            //    case Motorrad m:
            //        for (int i = 100; i < 200; i++)
            //        {
            //            if (this._stellplatzListe[i].Fahrzeug == null)
            //            {
            //                this._stellplatzListe[i].Fahrzeug = m;

            //                Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
            //                return true;
            //            }
            //        }

            //        return false;
            //    case LKW l:

            //        for (int i = 200; i < 300; i++)
            //        {
            //            if (this._stellplatzListe[i].Fahrzeug == null)
            //            {
            //                this._stellplatzListe[i].Fahrzeug = l;
            //                Program.stellplatzVerzeichnis.Add(_stellplatzListe[i].Fahrzeug.Kennzeichen, this.PID + "-" + _stellplatzListe[i].Nummer);
            //                return true;
            //            }
            //        }
            //        return false;
            //    default:
            //        return false;
            //}
        }

        public string fahrzeugParkplatzFinden(String kennzeichen)
        {
            kennzeichen = Program.ToUpperIgnoreDash(kennzeichen.Trim());
            try
            {
                return Program.stellplatzVerzeichnis[kennzeichen];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Fahrzeug nicht gefunden!");
                return "n/a";
            }
        }
    }
}
