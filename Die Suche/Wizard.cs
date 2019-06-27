using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class Wizard : Feind
    {
        public Wizard(Spiel spiel, Point ort) : base(spiel, ort, 30)
        {

        }

        public override void Bewegen(Random zufall)
        {
            if (FeindTrefferpunkte > 0)
            {
                    base.ort = Bewegen(SpielerrichtungSuchen(spiel.SpielerOrt), spiel.Grenzen);
                    if (NaheSpieler())
                    {
                        spiel.SpielerBekämpfen(8, zufall);
                    }
            }
            if (FeindTrefferpunkte < 15)
            {
                Teleport(zufall);
            }
        }

        private void Teleport(Random zufall)
        {
            if (ort.X + 200 < 850)
               ort.X += 200;
        }
    }
}
