using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class Sword : Waffe 
    {
        public Sword(Spiel spiel, Point ort) : base(spiel, ort)
        {
        }

        public override string Name { get { return "Schwert"; } }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            if (Upgrade == false)
            {
                switch (richtung)
                {
                    case Richtung.Hoch:
                        if (FeindVerletzen(Richtung.Hoch, 80, 3, zufall))
                            FeindVerletzen(Richtung.Hoch, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Rechts, 80, 3, zufall))
                            FeindVerletzen(Richtung.Rechts, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Links, 80, 3, zufall))
                            FeindVerletzen(Richtung.Links, 80, 3, zufall);
                        break;
                    case Richtung.Rechts:
                        if (FeindVerletzen(Richtung.Rechts, 80, 3, zufall))
                            FeindVerletzen(Richtung.Rechts, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Unten, 80, 3, zufall))
                            FeindVerletzen(Richtung.Unten, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Hoch, 80, 3, zufall))
                            FeindVerletzen(Richtung.Hoch, 80, 3, zufall);
                        break;
                    case Richtung.Unten:
                        if (FeindVerletzen(Richtung.Unten, 80, 3, zufall))
                            FeindVerletzen(Richtung.Unten, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Links, 80, 3, zufall))
                            FeindVerletzen(Richtung.Links, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Rechts, 80, 3, zufall))
                            FeindVerletzen(Richtung.Rechts, 80, 3, zufall);
                        break;
                    case Richtung.Links:
                        if (FeindVerletzen(Richtung.Links, 80, 3, zufall))
                            FeindVerletzen(Richtung.Links, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Unten, 80, 3, zufall))
                            FeindVerletzen(Richtung.Unten, 80, 3, zufall);
                        else if (FeindVerletzen(Richtung.Hoch, 80, 3, zufall))
                            FeindVerletzen(Richtung.Hoch, 80, 3, zufall);
                        break;
                }
            }
            if (Upgrade == true)
            {
                switch (richtung)
                {
                    case Richtung.Hoch:
                        if (FeindVerletzen(Richtung.Hoch, 100, 6, zufall))
                            FeindVerletzen(Richtung.Hoch, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Rechts, 100, 6, zufall))
                            FeindVerletzen(Richtung.Rechts, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Links, 100, 6, zufall))
                            FeindVerletzen(Richtung.Links, 100, 6, zufall);
                        break;
                    case Richtung.Rechts:
                        if (FeindVerletzen(Richtung.Rechts, 100, 6, zufall))
                            FeindVerletzen(Richtung.Rechts, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Unten, 100, 6, zufall))
                            FeindVerletzen(Richtung.Unten, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Hoch, 100, 6, zufall))
                            FeindVerletzen(Richtung.Hoch, 100, 6, zufall);
                        break;
                    case Richtung.Unten:
                        if (FeindVerletzen(Richtung.Unten, 100, 6, zufall))
                            FeindVerletzen(Richtung.Unten, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Links, 100, 6, zufall))
                            FeindVerletzen(Richtung.Links, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Rechts, 100, 6, zufall))
                            FeindVerletzen(Richtung.Rechts, 100, 6, zufall);
                        break;
                    case Richtung.Links:
                        if (FeindVerletzen(Richtung.Links, 100, 6, zufall))
                            FeindVerletzen(Richtung.Links, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Unten, 100, 6, zufall))
                            FeindVerletzen(Richtung.Unten, 100, 6, zufall);
                        else if (FeindVerletzen(Richtung.Hoch, 100, 6, zufall))
                            FeindVerletzen(Richtung.Hoch, 100, 6, zufall);
                        break;
                }
            }
          
        }

    }
}
