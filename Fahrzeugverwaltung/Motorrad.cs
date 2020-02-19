using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class Motorrad : Fahrzeug
    {
        public int Hubraum { get; set; }

        public Motorrad(String _hersteller, String _modell, String _kennzeichen, float _anschaffungspreis, int _pErstzulassung, int _hubraum)
     : base(_hersteller, _modell, _kennzeichen, _anschaffungspreis, _pErstzulassung)
        {
            Hubraum = _hubraum;
        }

        public override float steuerschuldBerechnen()
        {
            float steuerschuld = ((this.Hubraum + 99) / 100) * 20;
            return steuerschuld;
        }
        public override string ToString()
        {
            String fahrzeugDaten = "Hersteller: " + Hersteller + "\n" +
                "Modell: " + Modell + "\n" +
                "Erstzulassung: " + Erstzulassung + "\n" +
                "Kennzeichen: " + Kennzeichen + "\n" +
                                "Parkplatz: " + Program.stellplatzVerzeichnis[this.Kennzeichen] + "\n" +

                "Hubraum: " + Hubraum + "\n" +
                "Preis: " + Anschaffungspreis + "\n\n";
            return fahrzeugDaten;
        }
    }
}
