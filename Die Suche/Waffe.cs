using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    abstract class Waffe : Beweger
    {
        public bool Aufgesammelt { get; private set; }
        public Waffe(Spiel spiel, Point ort) :base(spiel, ort)
        {
            Aufgesammelt = false;
        }

        public void WaffeAufnehmen()
        {
            Aufgesammelt = true;
        }

        public abstract string Name { get; }

        public abstract void Angreifen(Richtung richtung, Random zufall, bool Upgrade);
       
        protected bool FeindVerletzen(Richtung richtung, int radius, int schaden, Random zufall)
        {
            Point ziel = spiel.SpielerOrt;
            for (int entfernung = 0; entfernung < radius; entfernung++)
            {
                foreach (Feind feind in spiel.Feind)
                {
                    if (NaheBei(feind.Ort, radius, spiel.SpielerOrt))
                    {
                        feind.Bekämpfen(schaden, zufall);
                        return true;
                    }
                }
                ziel = Bewegen(richtung, spiel.Grenzen);
            }
            return false;
        }
    }
}
