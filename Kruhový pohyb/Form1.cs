using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kruhový_pohyb
{
    public partial class Form1 : Form
    {
        //parametry kružnice
        int xStředuKružnice = 100;
        int yStředuKružnice = 100;
        int poloměrKružnice = 80;

        //parametry kuličky
        double úhel = 0; //Úhel průvodiče ve stupních
        double omega = 60; //úhlová rychlost ve stupních za sekundu
        int poloměrKuličky = 5;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;

            //výpočet pomocných hodnot pro kružnici
            int xLH = xStředuKružnice - poloměrKružnice;
            int yLH = yStředuKružnice - poloměrKružnice;
            int šířka = 2 * poloměrKružnice;
            int výška = šířka;

            //Kreslíme kružnici
            kp.DrawEllipse(Pens.CornflowerBlue, xLH, yLH, šířka, výška);

            //výpočet středu kuličky (NEJDŮLEŽITĚJŠÍ)
            double úhelRad = úhel * Math.PI / 100;
            double rozdílX = poloměrKružnice * Math.Cos(úhelRad);
            double rozdílY = poloměrKružnice * Math.Sin(úhelRad);
            double xStředuKuličky = xStředuKružnice + rozdílX;
            double yStředuKuličky = yStředuKružnice + rozdílY;

            //výpočet pomocných hodnot pro kuličku
            // ("Recyklujeme" jednnou použité pomocné proměnné)
            xLH = Convert.ToInt32(xStředuKuličky - poloměrKuličky);
            yLH = Convert.ToInt32(yStředuKuličky - poloměrKuličky);
            šířka = 2 * poloměrKuličky;
            výška = šířka;

            //kreslíme kuličku
            kp.FillEllipse(Brushes.CornflowerBlue, xLH, yLH, šířka, výška);






        }

        private void casovac_Tick(object sender, EventArgs e)
        {
            double čas = 0.001 * casovac.Interval;
            úhel += omega * čas;
            Refresh();
        }
    }
}
