using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class Goblin : Feind
    {
        public Goblin(Spiel spiel, Point ort, int Trefferpunkte) : base(spiel, ort, Trefferpunkte)
        {
        }

        public override void Bewegen(Random zufall)
        {
            int Zufallszahl = zufall.Next(1, 3);

            if (Zufallszahl == 3)
                base.ort = Bewegen(SpielerrichtungSuchen(spiel.SpielerOrt), spiel.Grenzen);
            else
                base.ort = Bewegen((Richtung)zufall.Next(0, 3), spiel.Grenzen);
            if (NaheSpieler())
            {
                spiel.SpielerBekämpfen(5, zufall);
            }
        }
    }
}
