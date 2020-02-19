using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class LKW: Fahrzeug
    {
        public int Achsenanzahl { get; set; }
        public float Zuladung { get; set; }

        public LKW(String _hersteller, String _modell, String _kennzeichen, float _anschaffungspreis, int _pErstzulassung, int _achsenanzahl, float _zuladung)
     : base(_hersteller, _modell, _kennzeichen, _anschaffungspreis, _pErstzulassung)
        {
            Achsenanzahl = _achsenanzahl;
            Zuladung = _zuladung;
        }

    public override float steuerschuldBerechnen()
        {
            float steuerschuld = (this.Zuladung * 100);
            return steuerschuld;
        }

        public override string ToString()
        {
            String fahrzeugDaten = "Hersteller: " + Hersteller + "\n" +
                "Modell: " + Modell + "\n" +
                "Erstzulassung: " + Erstzulassung + "\n" +
                "Kennzeichen: " + Kennzeichen + "\n" +
                                "Parkplatz: " + Program.stellplatzVerzeichnis[this.Kennzeichen] + "\n" +

                "Achsenanzahl: " + Achsenanzahl + "\n" +
                "Zuladung: " + Zuladung + "t \n" +
                "Preis: " + Anschaffungspreis + "\n\n";
            return fahrzeugDaten;
        }
    }

}
