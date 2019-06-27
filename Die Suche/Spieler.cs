using System;
using System.Collections.Generic;
using System.Drawing;

namespace Die_Suche
{
    class Spieler : Beweger
    {
        private Waffe verwendeteWaffe;
        public int Trefferpunkte { get; private set; }

        public int Mana { get; private set; }

        private List<Waffe> inventar = new List<Waffe>();
        public IEnumerable<string> Waffen
        {
            get
            {
                List<string> namen = new List<string>();
                foreach (Waffe waffe in inventar)
                    namen.Add(waffe.Name);
                return namen;
            }
        }
        public Spieler(Spiel spiel, Point ort) : base(spiel, ort)
        {
            Trefferpunkte = 12;
            Mana = 100;
        }

        public void Bekämpfen(int maxSchaden, Random zufall)
        {
            int Schaden = zufall.Next(1, maxSchaden);
            Trefferpunkte -= Schaden;
        }

        public void Ausrüsten(string waffenname)
        {
            foreach (Waffe waffe in inventar)
            {
                if ( waffe.Name == waffenname)
                {
                    verwendeteWaffe = waffe;
                }
            }
        }

        public void Bewegen(Richtung richtung)
        {
            base.ort = Bewegen(richtung, spiel.Grenzen);
            if (!spiel.WaffeInRaum.Aufgesammelt)
            {
                if(NaheBei(spiel.WaffeInRaum.Ort, 30, spiel.SpielerOrt))
                {
                    spiel.WaffeInRaum.WaffeAufnehmen();
                    inventar.Add(spiel.WaffeInRaum);
                    if (inventar.Count == 0)
                        Ausrüsten(spiel.WaffeInRaum.Name);
                }
            }

           if (spiel.SchmiedeInRaum != null)
            {
                if (NaheBei(spiel.SchmiedeInRaum.Ort, 50, spiel.SpielerOrt))
                {
                    if (verwendeteWaffe is Sword)
                    {
                        spiel.SchmiedeInRaum.FürSchwertBenutzen();
                    }
                    if (verwendeteWaffe is Bogen)
                    {
                        spiel.SchmiedeInRaum.FürBogenBenutzen();
                    }
                    if (verwendeteWaffe is Keule)
                    {
                        spiel.SchmiedeInRaum.FürKeuleBenutzen();
                    }
                    spiel.SchmiedeInRaum.SchmiedeBenutzen();
                }
            }
        }

        public void Angreifen(Richtung richtung, Random zufall)
        {
                if (verwendeteWaffe is Sword)
                {
                if (Schmiede.BenutztfürSchwert == true)
                {
                    verwendeteWaffe.Angreifen(richtung, zufall, true);
                }
                else
                    verwendeteWaffe.Angreifen(richtung, zufall, false);
                }
                   
           
            if (verwendeteWaffe is Bogen)
            {
                if (Schmiede.BenutztfürBogen == true)
                {
                    verwendeteWaffe.Angreifen(richtung, zufall, true);
                }
                else
                verwendeteWaffe.Angreifen(richtung, zufall, false);
            }
                

            if (verwendeteWaffe is Keule)
            {
                if (Schmiede.BenutztfürKeule == true)
                {
                    verwendeteWaffe.Angreifen(richtung, zufall, true);
                }
                else
                    verwendeteWaffe.Angreifen(richtung, zufall, false);
            }
               

            if (verwendeteWaffe is ITrank)
            {
                verwendeteWaffe.Angreifen(richtung, zufall, false);
            }
        }

        public void GesundheitErhöhen(int gesundheit, Random zufall)
        {
            Trefferpunkte += gesundheit;
        }

        public void ManaErhöhen(int mana)
        {
            this.Mana += mana;
        }

        public void ManaVerbrauchen(int mana)
        {
            this.Mana -= mana;
        }
    }
}

