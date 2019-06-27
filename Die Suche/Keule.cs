using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class Keule : Waffe
    {
        public Keule(Spiel spiel, Point ort) : base(spiel, ort)
        {
        }

        public override string Name
        {
            get
            {
                return "Keule";
            }
        }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            if (Upgrade)
            {
                FeindVerletzen(Richtung.Links, 80, 8, zufall);
                FeindVerletzen(Richtung.Hoch, 80, 8, zufall);
                FeindVerletzen(Richtung.Rechts, 80, 8, zufall);
                FeindVerletzen(Richtung.Unten, 80, 8, zufall);
            }
            else
            {
                FeindVerletzen(Richtung.Links, 80, 5, zufall);
                FeindVerletzen(Richtung.Hoch, 80, 5, zufall);
                FeindVerletzen(Richtung.Rechts, 80, 5, zufall);
                FeindVerletzen(Richtung.Unten, 80, 5, zufall);
            }
          
        }
    }
}
