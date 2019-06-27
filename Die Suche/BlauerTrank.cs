using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class BlauerTrank : Waffe, ITrank
    {
        public BlauerTrank(Spiel spiel, Point ort) : base(spiel, ort)
        {
        }

        public bool Aufgebraucht
        {    get; private set; }

        public override string Name
        {
            get
            {
                return "Blauer Trank";
            }
        }

        public override void Angreifen(Richtung richtung, Random zufall, bool Upgrade)
        {
            if (!Aufgebraucht)
            {
                spiel.SpielerManaErhöhen(100, zufall);
                Aufgebraucht = true;
            }    
        }
    }
}
