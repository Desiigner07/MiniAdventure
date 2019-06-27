using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class Ghul : Feind
    {
        public Ghul(Spiel spiel, Point ort, int trefferpunkte) :base(spiel, ort, trefferpunkte)
        {
        }

        public override void Bewegen(Random zufall)
        {
            int zufallszahl = zufall.Next(0, 2);
            if (zufallszahl == 0 || zufallszahl == 1)
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
