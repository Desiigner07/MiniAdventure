using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class Fledermaus2 : Feind
    {
        public Fledermaus2(Spiel spiel, Point ort) : base(spiel, ort, 6)
        {

        }
        public override void Bewegen(Random zufall)
        {
            if (!Tod)
            {
                if (zufall.Next(0, 1) == 0)
                {
                    base.ort = Bewegen(SpielerrichtungSuchen(spiel.SpielerOrt), spiel.Grenzen);
                    if (NaheSpieler())
                    {
                        spiel.SpielerBekämpfen(4, zufall);
                    }
                }
                else
                {
                    int zufallsZahl = zufall.Next(0, 3);
                    base.ort = Bewegen((Richtung)zufallsZahl, spiel.Grenzen);
                    if (NaheSpieler())
                    {
                        spiel.SpielerBekämpfen(4, zufall);
                    }
                }
            }
        }
    }
}
