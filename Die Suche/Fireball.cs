using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Die_Suche
{
    class Fireball : Waffe
    {
        public Fireball(Spiel spiel, Point ort) : base(spiel, ort)
        {
        }

        public override string Name
        {
            get
            {
                return "Feuerzauber";
            }
        }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            FeindVerletzen(Richtung.Links, 300, 10, zufall);
            FeindVerletzen(Richtung.Hoch, 300, 10, zufall);
            FeindVerletzen(Richtung.Rechts, 300, 10, zufall);
            FeindVerletzen(Richtung.Unten, 300, 10, zufall);
        }

      
        

      
    }
}
