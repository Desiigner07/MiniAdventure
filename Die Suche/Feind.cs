using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    abstract class Feind : Beweger
    {
        private const int SpielerNahdistanz = 50;
        public int FeindTrefferpunkte { get; private set; }
        public bool Tod { get
            {
                if (FeindTrefferpunkte <= 0)
                    return true;
                else
                    return false;
            }
                       }    

        public Feind(Spiel spiel, Point ort, int Trefferpunkte ) : base(spiel, ort)
        {
            this.FeindTrefferpunkte = Trefferpunkte;
        }

        public abstract void Bewegen(Random zufall);

        public void Bekämpfen(int maxSchaden, Random zufall)
        {
            FeindTrefferpunkte -= zufall.Next(1, maxSchaden);
        }

        protected bool NaheSpieler()
        {
            return (NaheBei(spiel.SpielerOrt, SpielerNahdistanz, ort));
        }

        protected Richtung SpielerrichtungSuchen( Point spielerOrt)
        {
            Richtung bewegungsrichtung;
            if (spielerOrt.X > ort.X + 10)
                bewegungsrichtung = Richtung.Rechts;
            else if (spielerOrt.X < ort.X - 10)
                bewegungsrichtung = Richtung.Links;
            else if (spielerOrt.Y < ort.Y - 10)
                bewegungsrichtung = Richtung.Hoch;
            else
                bewegungsrichtung = Richtung.Unten;
            return bewegungsrichtung;
        }
    }
}
