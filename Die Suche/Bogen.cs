using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class Bogen : Waffe
    {
        public Bogen(Spiel spiel, Point ort) : base(spiel, ort)
        {
        }

        public override string Name { get { return "Bogen"; } }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            if (!Upgrade)
                FeindVerletzen(richtung, 150, 1, zufall);
            else
                FeindVerletzen(richtung, 200, 5, zufall);
        }
    }
}
