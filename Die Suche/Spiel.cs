using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Die_Suche
{
    class Spiel
    {
        public List<Feind> Feind { get; private set; }
       
        public Waffe WaffeInRaum { get; private set; }

        public Schmiede SchmiedeInRaum { get; private set; }

        private Spieler spieler;
        public Point SpielerOrt { get { return spieler.Ort; } }
        public int SpielerTrefferpunkt { get { return spieler.Trefferpunkte; } }
        public int SpielerMana { get { return spieler.Mana; } }
        public IEnumerable<string> SpielerWaffen { get { return spieler.Waffen; } }

        private int level = 0;
        public int Level { get { return level; } }
        private Rectangle grenzen;
        public Rectangle Grenzen { get { return grenzen; } }

        public Spiel(Rectangle grenzen)
        {
            this.grenzen = grenzen;
            spieler = new Spieler(this, new Point(grenzen.Left, grenzen.Top + 105));
        }

        public void Bewegen(Richtung richtung, Random zufall)
        {
            spieler.Bewegen(richtung);
            foreach (Feind feind in Feind)
            {
                feind.Bewegen(zufall);
            }
            
        }

        public void Ausrüsten(string waffenname)
        {
            spieler.Ausrüsten(waffenname);
        }

        public bool SpielerInventarPrüfen(string waffenname)
        {
            return spieler.Waffen.Contains(waffenname);
        }

        public void SpielerBekämpfen(int maxschaden, Random zufall)
        {
            spieler.Bekämpfen(maxschaden, zufall);
        }

        public void SpielerGesundheitErhöhen (int gesundheit, Random zufall)
        {
            spieler.GesundheitErhöhen(gesundheit, zufall);
        }
        public void SpielerManaErhöhen(int mana, Random zufall)
        {
            spieler.ManaErhöhen(mana);
        }
        public void SpielerManaVerbrauchen(int mana)
        {
            spieler.ManaVerbrauchen(mana);
        }
        public void Angreifen(Richtung richtung, Random zufall)
        {
            spieler.Angreifen(richtung, zufall);
            foreach (Feind feind in Feind)
                feind.Bewegen(zufall);
        }

        private Point ZufallsortGenerieren(Random zufall)
        {
            return new Point(grenzen.Left +
                zufall.Next(grenzen.Right / 10 - grenzen.Left / 10) * 10,
                grenzen.Top +
                zufall.Next(grenzen.Bottom / 10 - grenzen.Top / 10) * 10);
        }

        public void NeuesLevel(Spiel spiel, Random zufall)
        {
            level++;
            switch(level)
            {
                case 1:
                    Feind = new List<Feind>()
                    {
                        new Fledermaus(this, new Point(724, 231))
                    };
                    WaffeInRaum = new Sword(this, new Point(224, 80));
                    break;

                case 2:
                    Feind = new List<Feind>()
                    {
                        new Geist(this,new Point(425, 183), 8)
                    };
                    WaffeInRaum = new RoterTrank(this, new Point(326, 285));
                    break;

                case 3:
                    Feind = new List<Feind>()
                    {
                        new Ghul(this, new Point(571, 130), 10)
                    };
                    WaffeInRaum = new Bogen(this, new Point(425, 80));
                    break;

                case 4:
                    Feind = new List<Feind>()
                    {
                          new Geist(this, new Point(425, 183), 8),
                         new Fledermaus(this, new Point(724, 231))
                    };

                 if (SpielerInventarPrüfen("Bogen"))
                        WaffeInRaum = new BlauerTrank(this, new Point(326, 285));
                    else
                    WaffeInRaum = new Bogen(this, new Point(425, 80));
                    break;

                case 5:
                    Feind = new List<Feind>()
                    {
                          new Fledermaus(this, new Point(724, 231)),
                        new Ghul(this, new Point(571, 130), 10)
                    };
                    WaffeInRaum = new RoterTrank(this, new Point(771, 130));
                    break;

                case 6:
                    Feind = new List<Feind>()
                    {
                       new Geist(this,new Point(425, 183), 8),
                       new Ghul(this, new Point(571, 130), 10)
                    };
                    WaffeInRaum = new Keule(this, new Point(522, 283));
                    break;

                case 7:
                    Feind = new List<Feind>()
                    {
                         new Fledermaus(this, new Point(724, 181)),
                          new Geist(this,new Point(425, 183), 8),
                            new Ghul(this, new Point(571, 130), 10)
                    };
                    WaffeInRaum = new BlauerTrank(this, new Point(326, 285));
                    break;
                case 8:
                    Feind = new List<Feind>()
                    {
                         new Goblin(this, new Point(670, 80), 15),
                          new Geist(this,new Point(425, 183), 8),
                            new Ghul(this, new Point(571, 130), 10)
                    };
                    WaffeInRaum = new RoterTrank(this, new Point(771, 130));
                    SchmiedeInRaum = new Die_Suche.Schmiede(this, new Point(124, 80));
                    break;
                case 9:
                    Feind = new List<Feind>()
                    {
                        new Wizard(this, new Point(824, 182))
                    };
                    WaffeInRaum = new RoterTrank(this, new Point(771, 130));
                    break;
                case 20:
                    SchmiedeInRaum = new Die_Suche.Schmiede(this, new Point(124, 80));
                    ZufallslevelGenerieren(spiel, zufall);
                    break;
                case 30:
                    SchmiedeInRaum = new Die_Suche.Schmiede(this, new Point(124, 80));
                    ZufallslevelGenerieren(spiel, zufall);
                    break;
                case 40:
                    SchmiedeInRaum = new Die_Suche.Schmiede(this, new Point(124, 80));
                    ZufallslevelGenerieren(spiel, zufall);
                    break;
                default:
                    ZufallslevelGenerieren(spiel, zufall);
                    break;
            }
        }


        public void ZufallslevelGenerieren(Spiel spiel, Random zufall)
        {
            int Münze = zufall.Next(1, 4);
            int ZufallsLeben = zufall.Next(10, 20);
            if ( Münze == 1)
            {
                Feind = new List<Die_Suche.Feind>()
                {
                     new Fledermaus(this, new Point(724, 181)),
                          new Geist(this,new Point(425, 183), ZufallsLeben),
                            new Ghul(this, new Point(571, 130), 10)
                };
                WaffeInRaum = new RoterTrank(this, new Point(771, 130));

            }
            if (Münze == 2)
            {
                Feind = new List<Die_Suche.Feind>()
                {
                     new Fledermaus(this, new Point(724, 181)),
                          new Ghul(this,new Point(571, 130), ZufallsLeben),
                            new Wizard(this, new Point(824, 182))
                };
                WaffeInRaum = new RoterTrank(this, new Point(771, 130));
            }
            if (Münze == 3)
            {
                Feind = new List<Die_Suche.Feind>()
                {
                     new Fledermaus2(this, new Point(571, 231)),
                          new Ghul(this,new Point(571, 130), ZufallsLeben),
                            new Fledermaus(this, new Point(724, 231))
                };
                WaffeInRaum = new RoterTrank(this, new Point(771, 130));
            }
            if (Münze == 4)
            {
                Feind = new List<Die_Suche.Feind>()
                {
                     new Geist(this, new Point(425, 183), ZufallsLeben),
                          new Ghul(this,new Point(571, 130), ZufallsLeben),
                            new Fledermaus(this, new Point(724, 231)),
                             new Fledermaus2(this, new Point(571, 231))
                };
                WaffeInRaum = new BlauerTrank(this, new Point(326, 285));
            }
        }
    }
}
