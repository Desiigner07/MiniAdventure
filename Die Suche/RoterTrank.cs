using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class RoterTrank : Waffe, ITrank
    {
        public RoterTrank(Spiel spiel, Point ort) :base(spiel, ort)
        {
        }
        public override string Name
        {
            get
            {
                return "Roter Trank";
            }
        }
        public bool Aufgebraucht { get; private set; }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            if (!Aufgebraucht)
            {
                spiel.SpielerGesundheitErhöhen(12, zufall);
                Aufgebraucht = true;
            }
        }
    }
}
