using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Die_Suche
{
    enum Richtung
    {
        Hoch,
        Rechts,
        Unten,
        Links
    }
    abstract class Beweger
    {
        private const int SchrittGröße = 50;
        protected Point ort;
        public Point Ort { get { return ort; } }
        protected Spiel spiel;

        public Beweger(Spiel spiel, Point ort)
        {
            this.spiel = spiel;
            this.ort = ort;
        }

        public bool NaheBei (Point zuPrüfenderOrt, int entfernung, Point DeinOrt)
        {
            if (Math.Abs(DeinOrt.X - zuPrüfenderOrt.X) < entfernung &&
                Math.Abs(DeinOrt.Y - zuPrüfenderOrt.Y) < entfernung)
            {
                return true;
            }
            else
                return false;
        }
       

    public Point Bewegen(Richtung richtung, Rectangle grenzen)
    {
            Point neuerOrt = ort;
            switch (richtung)
            {
                case Richtung.Hoch:
                    if (neuerOrt.Y - SchrittGröße >= grenzen.Top)
                        neuerOrt.Y -= SchrittGröße;
                    break;
                case Richtung.Unten:
                    if (neuerOrt.Y + SchrittGröße <= grenzen.Bottom)
                        neuerOrt.Y += SchrittGröße;
                    break;
                case Richtung.Links:
                    if (neuerOrt.X - SchrittGröße >= grenzen.Left)
                        neuerOrt.X -= SchrittGröße;
                    break;
                case Richtung.Rechts:
                    if (neuerOrt.X + SchrittGröße <= grenzen.Right)
                        neuerOrt.X += SchrittGröße;
                    break;
            }
            return neuerOrt;
    }
    }
}

