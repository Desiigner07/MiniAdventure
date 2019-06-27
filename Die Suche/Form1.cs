using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Die_Suche
{
    public partial class Form1 : Form
    {
        private Spiel spiel;
        private Random zufall = new Random();
       
        public Form1()
        {
            InitializeComponent();
            spiel = new Die_Suche.Spiel(new Rectangle(124, 78, 724, 240));
            spiel.NeuesLevel(spiel, zufall);
            FigurenAktualisieren();

            fire1.Visible = false;
            fire2.Visible = false;
            fire3.Visible = false;
            fire4.Visible = false;
            mana.Height = 30;
        }

        PictureBox mana = new PictureBox();
        Point Wizardleben = new Point();
        private void FigurenAktualisieren()
        {
            LevelAnzeige.Text = "Level " + spiel.Level;

            //Spieler und Gegner
            Player.Location = spiel.SpielerOrt;
            bat2.Visible = false;
            batLeben2.Visible = false;
            bat.Visible = false;
            ghost.Visible = false;
            ghoul.Visible = false;
            BatLeben.Visible = false;
            GhostLeben.Visible = false;
            GhoulLeben.Visible = false;
            goblin.Visible = false;
            Goblinleben.Visible = false;
            Wizard.Visible = false;
            WizardLeben.Visible = false;

            int FeindeInLevel = 0;
            foreach (Feind feind in spiel.Feind)
            {
                if (feind is Fledermaus)
                {
                    if (feind.FeindTrefferpunkte > 0)
                    {
                        bat.Visible = true;
                        BatLeben.Visible = true;
                        bat.Location = feind.Ort;
                        BatLeben.Location = bat.Location;
                        BatLeben.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else if (feind.FeindTrefferpunkte < 1)
                    {
                        spiel.Feind.Remove(feind);
                        bat.Visible = false;
                        BatLeben.Visible = false;
                        break;
                    }  
                }

                if (feind is Fledermaus2)
                {
                    if (feind.FeindTrefferpunkte > 0)
                    {
                        bat2.Visible = true;
                        batLeben2.Visible = true;
                        bat2.Location = feind.Ort;
                        batLeben2.Location = bat.Location;
                        batLeben2.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else if (feind.FeindTrefferpunkte < 1)
                    {
                        spiel.Feind.Remove(feind);
                        bat2.Visible = false;
                        batLeben2.Visible = false;
                        break;
                    }
                }
                if (feind is Geist)
                {
                    if (feind.FeindTrefferpunkte > 0)
                    {
                        ghost.Visible = true;
                        GhostLeben.Visible = true;
                        ghost.Location = feind.Ort;
                        GhostLeben.Location = ghost.Location;
                        GhostLeben.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else if (feind.FeindTrefferpunkte < 1)
                    {
                        spiel.Feind.Remove(feind);
                        ghost.Visible = false;
                        GhostLeben.Visible = false;
                        break;
                    }   
                }
                if (feind is Ghul)
                {
                    if (feind.FeindTrefferpunkte > 0)
                    {
                        ghoul.Visible = true;
                        GhoulLeben.Visible = true;
                        ghoul.Location = feind.Ort;
                        GhoulLeben.Location = ghoul.Location;
                        GhoulLeben.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else if (feind.FeindTrefferpunkte < 1)
                    {
                        spiel.Feind.Remove(feind);
                        ghoul.Visible = false;
                        GhoulLeben.Visible = false;
                        break;
                    }
                }
                if (feind is Goblin)
                {
                    if (feind.FeindTrefferpunkte > 0)
                    {
                        goblin.Visible = true;
                        Goblinleben.Visible = true;
                        goblin.Location = feind.Ort;
                        Goblinleben.Location = goblin.Location;
                        Goblinleben.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else if (feind.FeindTrefferpunkte < 1)
                    {
                        spiel.Feind.Remove(feind);
                        goblin.Visible = false;
                        Goblinleben.Visible = false;
                        break;
                    }
                }
                if (feind is Wizard)
                {
                    if (!feind.Tod)
                    {
                        Wizard.Visible = true;
                        WizardLeben.Visible = true;
                        Wizard.Location = feind.Ort;
                        Wizardleben.X = Wizard.Location.X - 10;
                        Wizardleben.Y = Wizard.Location.Y - 20;
                        WizardLeben.Location = Wizardleben;
                        WizardLeben.Value = feind.FeindTrefferpunkte;
                        FeindeInLevel++;
                    }
                    else
                    {
                        spiel.Feind.Remove(feind);
                        Wizard.Visible = false;
                        WizardLeben.Visible = false;
                        break;
                    }
                }
            }


            //Waffen und Inventar
            schmiede.Visible = false;
                Sword.Visible = false;
                Bow.Visible = false;
                Mace.Visible = false;
                RoterTrank.Visible = false;
                BlauerTrank.Visible = false;
                Control waffenSteuerung = null;
                switch (spiel.WaffeInRaum.Name)
                {
                    case "Schwert":
                        waffenSteuerung = Sword;
                        Sword.Location = spiel.WaffeInRaum.Ort;
                        break;
                    case "Bogen":
                        waffenSteuerung = Bow;
                        Bow.Location = spiel.WaffeInRaum.Ort;
                        break;
                    case "Keule":
                        waffenSteuerung = Mace;
                        Mace.Location = spiel.WaffeInRaum.Ort;
                        break;
                    case "Blauer Trank":
                        waffenSteuerung = BlauerTrank;
                        BlauerTrank.Location = spiel.WaffeInRaum.Ort;
                        break;
                    case "Roter Trank":
                        waffenSteuerung = RoterTrank;
                        RoterTrank.Location = spiel.WaffeInRaum.Ort;
                        break;
                }

            WaffenUpgrade();
            mana.Width = spiel.SpielerMana;
            ManaBar.Size = mana.Size;
            TrankAnzahl();

            if (spiel.SpielerMana >= 50)
                Fireball.Enabled = true;
            else
                Fireball.Enabled = false;

                InventoryPlace1.Visible = false;
                InventoryPlace2.Visible = false;
                InventoryPlace3.Visible = false;
                InventoryPlace4.Visible = false;
                InventoryPlace5.Visible = false;

           
                if (spiel.SpielerInventarPrüfen("Schwert"))
                {
                    InventoryPlace1.Visible = true;
                    Sword.Visible = false;
                }
                if (spiel.SpielerInventarPrüfen("Bogen"))
                {
                    InventoryPlace2.Visible = true;
                    Bow.Visible = false;
                }
                if (spiel.SpielerInventarPrüfen("Keule"))
                {
                    InventoryPlace3.Visible = true;
                    Mace.Visible = false;
                }
                if (spiel.SpielerInventarPrüfen("Blauer Trank"))
                {
                    InventoryPlace4.Visible = true;
                    BlauerTrank.Visible = false;
                }
                if (spiel.SpielerInventarPrüfen("Roter Trank"))
                {
                    InventoryPlace5.Visible = true;
                    RoterTrank.Visible = false;
                }

         


                if (spiel.SchmiedeInRaum != null)
            {
                if (spiel.SchmiedeInRaum.BenutztImLevel)
                {
                    schmiede.Visible = false;
                }
                else
                {
                    schmiede.Visible = true;
                }
            }
          

                if (spiel.WaffeInRaum.Aufgesammelt)
                {
                    waffenSteuerung.Visible = false;
                }
                else
                    waffenSteuerung.Visible = true;

                if (spiel.SpielerTrefferpunkt <= 0)
                {
                    MessageBox.Show("Sie sind tot, Sie haben " + spiel.Level +  " Level Überlebt. " + GloryMessage(), "Game Over!");
                    Application.Exit();
                }
               
                if (spiel.SpielerTrefferpunkt > 0 && spiel.SpielerTrefferpunkt < 21)
                SpielerLeben.Value = spiel.SpielerTrefferpunkt;

                if (spiel.Feind.Count == 0)
                {
                    MessageBox.Show("Sie haben alle Feinde in diesem Level besiegt");
                    spiel.NeuesLevel(spiel, zufall);
                    FigurenAktualisieren();
                } 
            }

        Bitmap UpgradeSword = new Bitmap(@"C:\Users\pohly\Documents\Visual Studio 2015\Projects\Die Suche\Die Suche\Grafiken\swordUpgrade.PNG");
        Bitmap UpgradeBow = new Bitmap(@"C:\Users\pohly\Documents\Visual Studio 2015\Projects\Die Suche\Die Suche\Grafiken\bomb.png");
        Bitmap UpgradeMace = new Bitmap(@"C:\Users\pohly\Documents\Visual Studio 2015\Projects\Die Suche\Die Suche\Grafiken\battleaxe.png");
        public void WaffenUpgrade()
        {
            if (Schmiede.BenutztfürSchwert)
            InventoryPlace1.Image = UpgradeSword;

            if (Schmiede.BenutztfürBogen)
                InventoryPlace2.Image = UpgradeBow;

            if (Schmiede.BenutztfürKeule)
                InventoryPlace3.Image = UpgradeMace;
        }

        private void TrankAnzahl()
        {
            int RoterTrankAnzahl = 0;
            int BlauerTrankAnzahl = 0;
            foreach (String waffe in spiel.SpielerWaffen)
            {
                if (waffe == "Roter Trank")
                {
                    RoterTrankAnzahl++;
                }
                if (waffe == "Blauer Trank")
                {
                    BlauerTrankAnzahl++;
                }
            }
            blauerTrankAnzahl.Text = BlauerTrankAnzahl.ToString();
            roterTrankAnzahl.Text = RoterTrankAnzahl.ToString();
        }

        private string GloryMessage()
        {
            if (spiel.Level < 5)
            {
                return "Du spielst Scheiße!";
            }
            else if (spiel.Level < 10)
            {
                return "Wenn die Zukunft der Menschheit in deinen Händen liegt, sind wir verloren";
            }
            else if (spiel.Level < 20)
            {
                return "Nicht Schlecht aber das geht besser";
            }
            else
                return "Wow da hab ich wohl Einen Helden vor mir!";

        }

        private void InventoryPlace1_Click(object sender, EventArgs e)
        {
            spiel.Ausrüsten("Schwert");
            InventoryPlace1.BackColor = Color.LightGoldenrodYellow;
            InventoryPlace2.BackColor = Color.Transparent;
            InventoryPlace3.BackColor = Color.Transparent;
            InventoryPlace4.BackColor = Color.Transparent;
            InventoryPlace5.BackColor = Color.Transparent;
        }

        private void InventoryPlace2_Click(object sender, EventArgs e)
        {
            spiel.Ausrüsten("Bogen");
            InventoryPlace1.BackColor = Color.Transparent;
            InventoryPlace2.BackColor = Color.LightGoldenrodYellow;
            InventoryPlace3.BackColor = Color.Transparent;
            InventoryPlace4.BackColor = Color.Transparent;
            InventoryPlace5.BackColor = Color.Transparent;
        }

        private void InventoryPlace3_Click(object sender, EventArgs e)
        {
            spiel.Ausrüsten("Keule");
            InventoryPlace1.BackColor = Color.Transparent;
            InventoryPlace2.BackColor = Color.Transparent;
            InventoryPlace3.BackColor = Color.LightGoldenrodYellow;
            InventoryPlace4.BackColor = Color.Transparent;
            InventoryPlace5.BackColor = Color.Transparent;
        }

        private void InventoryPlace4_Click(object sender, EventArgs e)
        {
            spiel.Ausrüsten("Blauer Trank");
            InventoryPlace1.BackColor = Color.Transparent;
            InventoryPlace2.BackColor = Color.Transparent;
            InventoryPlace3.BackColor = Color.Transparent;
            InventoryPlace4.BackColor = Color.LightGoldenrodYellow;
            InventoryPlace5.BackColor = Color.Transparent;
        }

        private void InventoryPlace5_Click(object sender, EventArgs e)
        {
            spiel.Ausrüsten("Roter Trank");
            InventoryPlace1.BackColor = Color.Transparent;
            InventoryPlace2.BackColor = Color.Transparent;
            InventoryPlace3.BackColor = Color.Transparent;
            InventoryPlace4.BackColor = Color.Transparent;
            InventoryPlace5.BackColor = Color.LightGoldenrodYellow;
        }

        Timer LeftMoveTimer = new Timer();
        private void Left_Click(object sender, EventArgs e)
        {
            Moving = 0;
            LeftMoveTimer.Interval = 20;
            LeftMoveTimer.Tick += LeftMoveTimer_Tick;
            LeftMoveTimer.Start();
            FigurenAktualisieren();
            BlockButtons(true);
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            Moving++;
            if (Moving < 50)
            {
                Point Zielort = new Point(spiel.SpielerOrt.X - Moving, spiel.SpielerOrt.Y);
                Player.Location = Zielort;
               
            }
            else if (Moving == 50)
            {
                LeftMoveTimer.Stop();
                spiel.Bewegen(Richtung.Links, zufall);
                Player.Location = spiel.SpielerOrt;
                FigurenAktualisieren();
                BlockButtons(false);
            }
        }

        Timer UpMoveTimer = new Timer();
        private void Up_Click(object sender, EventArgs e)
        {
            Moving = 0;
            UpMoveTimer.Interval = 20;
            UpMoveTimer.Tick += UpMoveTimer_Tick;
            UpMoveTimer.Start();
            FigurenAktualisieren();
            BlockButtons(true);
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            Moving++;
            if (Moving < 50)
            {
                Point Zielort = new Point(spiel.SpielerOrt.X, spiel.SpielerOrt.Y - Moving);
                Player.Location = Zielort;
            }
            else if (Moving == 50)
            {
                UpMoveTimer.Stop();
                spiel.Bewegen(Richtung.Hoch, zufall);
                Player.Location = spiel.SpielerOrt;
                FigurenAktualisieren();
                BlockButtons(false);
            }
        }

        Timer RightMoveTimer = new Timer();
        private void Right_Click(object sender, EventArgs e)
        {
            Moving = 0;
            RightMoveTimer.Interval = 20;
            RightMoveTimer.Tick += RightMoveTimer_Tick;
            RightMoveTimer.Start();
            FigurenAktualisieren();
            BlockButtons(true);
        }
        int Moving;
        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            Moving++;
            if (Moving < 50)
            {
               Point Zielort = new Point(spiel.SpielerOrt.X + Moving, spiel.SpielerOrt.Y);
                Player.Location = Zielort;
            }
            else if (Moving == 50)
            {
                RightMoveTimer.Stop();
                spiel.Bewegen(Richtung.Rechts, zufall);
                Player.Location = spiel.SpielerOrt;
                FigurenAktualisieren();
                BlockButtons(false);
            }
           
        }

        Timer DownMoveTimer = new Timer();
        private void Down_Click(object sender, EventArgs e)
        {
            Moving = 0;
            DownMoveTimer.Interval = 20;
            DownMoveTimer.Tick += DownMoveTimer_Tick;
            DownMoveTimer.Start();
            FigurenAktualisieren();
            BlockButtons(true);
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            Moving++;
            if (Moving < 50)
            {
                Point Zielort = new Point(spiel.SpielerOrt.X, spiel.SpielerOrt.Y + Moving);
                Player.Location = Zielort;
            }
            else if (Moving == 50)
            {
                DownMoveTimer.Stop();
                spiel.Bewegen(Richtung.Unten, zufall);
                Player.Location = spiel.SpielerOrt;
                FigurenAktualisieren();
                BlockButtons(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spiel.Angreifen(Richtung.Hoch, zufall);
            FigurenAktualisieren();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            spiel.Angreifen(Richtung.Rechts, zufall);
            FigurenAktualisieren();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            spiel.Angreifen(Richtung.Unten, zufall);
            FigurenAktualisieren();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spiel.Angreifen(Richtung.Links, zufall);
            FigurenAktualisieren();
        }


        private void BlockButtons(bool block)
        {
            if (block)
            {
                Right.Enabled = false;
                Left.Enabled = false;
                Up.Enabled = false;
                Down.Enabled = false;
            }
            else if (!block)
            {
                Right.Enabled = true;
                Left.Enabled = true;
                Up.Enabled = true;
                Down.Enabled = true;
            }
        }

#region

        //Feuerzauber und Animation
        System.Windows.Forms.Timer FireAnimationtimer = new System.Windows.Forms.Timer();
        int Controll = 0;
        int locationX;
        int locationY;
        private void Fireball_Click(object sender, EventArgs e)
        {
            if (spiel.SpielerMana >= 50)
            {
                fire1.Visible = true;
                fire2.Visible = true;
                fire3.Visible = true;
                fire4.Visible = true;

                spiel.SpielerManaVerbrauchen(50);

                Fireball fireball = new Die_Suche.Fireball(spiel, spiel.SpielerOrt);
                fireball.Angreifen(Richtung.Rechts, zufall, false);
                Controll = 0;
                locationX = Player.Location.X;
                locationY = Player.Location.Y;
                FireAnimationtimer.Interval = 10;
                FireAnimationtimer.Tick += Timer_Tick;
                FireAnimationtimer.Start();
                FigurenAktualisieren();
            }
         
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Controll < 200)
            {
                Controll += 2;
                Point location2 = new Point(locationX + Controll, locationY);
                fire2.Location = location2;

                Point location4 = new Point(locationX - Controll, locationY);
                fire4.Location = location4;

                Point location1 = new Point(locationX, locationY - Controll);
                fire1.Location = location1;

                Point location3 = new Point(locationX, locationY + Controll);
                fire3.Location = location3;
            }
            else
            {
                FireAnimationtimer.Stop();
                fire1.Visible = false;
                fire2.Visible = false;
                fire3.Visible = false;
                fire4.Visible = false;
            }
        }

        #endregion

    }
}
