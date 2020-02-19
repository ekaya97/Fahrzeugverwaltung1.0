using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    public enum Schadstoffklasse {
        Schadstoffarm = 0,
        Normal = 1,
        Diesel = 2,
    }

    class Fahrzeug
    {
        public String Hersteller { get; set; }
        public String Modell { get; set; }
        public String Kennzeichen { get; set; }
        public String Parkplatz { get; set; }
        public float Anschaffungspreis { get; set; }
        private int _erstzulassung;

        public int Erstzulassung
        {
            get { return _erstzulassung; }
            set {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} darf nicht in der Zukunft liegen");
                }
                else
                {
                    _erstzulassung = value;
                }
            }
        }

        public Fahrzeug(String _hersteller, String _modell, String _kennzeichen, float _anschaffungspreis, int _pErstzulassung)
        {
            Hersteller = _hersteller;
            Modell = _modell;
            Kennzeichen = _kennzeichen;
            Anschaffungspreis = _anschaffungspreis;
            Erstzulassung = _pErstzulassung;
        }

        public virtual float steuerschuldBerechnen()
        {
            throw new ArgumentException(
                "Kein Fahrzeug spezifiziert!");
        }


        public override string ToString()
        {
            String fahrzeugDaten = "Hersteller: " + Hersteller + "\n" +
                "Modell: " + Modell + "\n" +
                "Erstzulassung: " + Erstzulassung + "\n" +
                "Kennzeichen: " + Kennzeichen + "\n" +
                "Parkplatz: " + Program.stellplatzVerzeichnis[this.Kennzeichen] + "\n" +
                "Preis: " + Anschaffungspreis + "\n";
            return fahrzeugDaten;
        }
    }
}
