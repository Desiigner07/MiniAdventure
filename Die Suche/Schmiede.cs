using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Suche
{
    class Schmiede : Beweger
    {
        public Schmiede(Spiel spiel, Point ort) :base(spiel, ort)
        {
            BenutztfürSchwert = false;
            BenutztfürBogen = false;
            BenutztfürKeule = false;
            BenutztImLevel = false;
        }
        public static bool BenutztfürSchwert { get; private set; }
        public static bool BenutztfürBogen { get; private set; }
        public static bool BenutztfürKeule { get; private set; }
        public bool BenutztImLevel { get; private set; }
       
        public void SchmiedeBenutzen()
        {
            BenutztImLevel = true;
        }

        public void FürSchwertBenutzen()
        {
            BenutztfürSchwert = true;
        }
        public void FürBogenBenutzen()
        {
            BenutztfürBogen = true;
        }
        public void FürKeuleBenutzen()
        {
            BenutztfürKeule = true;
        }
      
    }
}
