using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    class PKW : Fahrzeug
    {
        public int Hubraum { get; set; }
        public int Leistung { get; set; }

        private Schadstoffklasse schadstoffklasse{get; set;}


        public PKW(String _hersteller, String _modell, String _kennzeichen, float _anschaffungspreis, int _pErstzulassung, int _hubraum, int _leistung, Schadstoffklasse _schadstoffklasse)
            : base(_hersteller, _modell, _kennzeichen, _anschaffungspreis, _pErstzulassung)
        {
            Hubraum = _hubraum;
            Leistung = _leistung;
            schadstoffklasse = _schadstoffklasse;
        }


        public override float steuerschuldBerechnen()
        {
            float steuerschuld = ((((this.Hubraum+99)/100)*10)* (int)this.schadstoffklasse + 1);
       
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
                "Leistung: " + Leistung + "\n" +
                "Schadstoffklasse: " + schadstoffklasse + "\n" +
                "Preis: " + Anschaffungspreis + "\n\n";
            return fahrzeugDaten;
        }
    }
}
