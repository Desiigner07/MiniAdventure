using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class Geist : Feind
    {
        public Geist(Spiel spiel, Point ort, int trefferpunkte) : base(spiel, ort, trefferpunkte)
        {

        }

        public override void Bewegen(Random zufall)
        {
            if (FeindTrefferpunkte > 0)
            {
                int zufallszahl = zufall.Next(0, 2);
                if (zufallszahl == 1)                             //Der Geist bewegt sich nur in 1 von 3 Fällen
                {
                    base.ort = Bewegen(SpielerrichtungSuchen(spiel.SpielerOrt), spiel.Grenzen);
                    if (NaheSpieler())
                    {
                        spiel.SpielerBekämpfen(4, zufall);
                    }
                }
            }
           
               
           
        }
    }
}
