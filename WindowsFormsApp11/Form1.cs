using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {

        System.Drawing.Graphics Cizgi;
        Pen Klm = new Pen(Color.Red, 2);
        Double[,] UcgenCismi = new Double[3, 4] { { 2, 3,0,1 },{7, 3,0,1 },{2, 6,0,1 } };
        Double[,] Eksen2BX = new double[2, 2] { { -1.95, 0 }, { 1.95, 0 } };
        Double[,] Eksen2BY = new double[2, 2] { { 0, 1.95 }, { 0, -1.95 } };
        Double[,] UcgenYansitXY = new double[4, 4] { { 1,0,0,0 },
                                                  { 0,-1,0,0 },
                                                  { 0,0,0,0},
                                                  { 0,0,0,1 } };


        Double[,] YansimisUcgen = new double[3, 4];
        Double[,] Tdondur = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

        int i;
        int j;
        int k;




    

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cizgi = this.CreateGraphics();
            Cizgi.DrawLine(Klm, KordinatHesaplaX(Eksen2BX[0, 0]), KordinatHesaplaY(Eksen2BX[0, 1]), KordinatHesaplaX(Eksen2BX[1, 0]), KordinatHesaplaY(Eksen2BX[1, 1]));
            Cizgi.DrawLine(Klm, KordinatHesaplaX(Eksen2BY[0, 0]), KordinatHesaplaY(Eksen2BY[0, 1]), KordinatHesaplaX(Eksen2BY[1, 0]), KordinatHesaplaY(Eksen2BY[1, 1]));
            Cizgi.Dispose();
        }

        private int KordinatHesaplaX(Double geciciX)
        {
            return Convert.ToInt32(275 + 150 + (100 * geciciX));
        }
        private int KordinatHesaplaY(Double geciciY)
        {
            return Convert.ToInt32(100 + 150 + (-100 * geciciY));
        }
        private int UcgenHesaplaX(Double geciciX)
        {
            return Convert.ToInt32(275 + 150 + (25 * geciciX));
        }
        private int UcgenHesaplaY(Double geciciY)
        {
            return Convert.ToInt32(100 + 150 + (-25 * geciciY));
        }

        private int YansimisUcgenHesaplaX(Double geciciX)
        {
            return Convert.ToInt32(275 + 150 + (25 * geciciX));
        }
        private int YansimisUcgenHesaplaY(Double geciciY)
        {
            return Convert.ToInt32(100 + 150 + (-25 * geciciY));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cizgi = this.CreateGraphics();
            Cizgi.DrawLine(Klm, UcgenHesaplaX(UcgenCismi[0, 0]), UcgenHesaplaY(UcgenCismi[0, 1]), UcgenHesaplaX(UcgenCismi[1, 0]), UcgenHesaplaY(UcgenCismi[1, 1]));
            Cizgi.DrawLine(Klm, UcgenHesaplaX(UcgenCismi[1, 0]), UcgenHesaplaY(UcgenCismi[1, 1]), UcgenHesaplaX(UcgenCismi[2, 0]), UcgenHesaplaY(UcgenCismi[2, 1]));
            Cizgi.DrawLine(Klm, UcgenHesaplaX(UcgenCismi[2, 0]), UcgenHesaplaY(UcgenCismi[2, 1]), UcgenHesaplaX(UcgenCismi[0, 0]), UcgenHesaplaY(UcgenCismi[0, 1]));
            Cizgi.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    YansimisUcgen[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        YansimisUcgen[i, j] += UcgenCismi[i, k] * UcgenYansitXY[k, j];
                    }
                }
            }
            Pen Klm = new Pen(Color.Blue, 2);
            Cizgi = this.CreateGraphics();
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(YansimisUcgen[0, 0]), YansimisUcgenHesaplaY(YansimisUcgen[0, 1]), YansimisUcgenHesaplaX(YansimisUcgen[1, 0]), YansimisUcgenHesaplaY(YansimisUcgen[1, 1]));
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(YansimisUcgen[1, 0]), YansimisUcgenHesaplaY(YansimisUcgen[1, 1]), YansimisUcgenHesaplaX(YansimisUcgen[2, 0]), YansimisUcgenHesaplaY(YansimisUcgen[2, 1]));
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(YansimisUcgen[2, 0]), YansimisUcgenHesaplaY(YansimisUcgen[2, 1]), YansimisUcgenHesaplaX(YansimisUcgen[0, 0]), YansimisUcgenHesaplaY(YansimisUcgen[0, 1]));
            Cizgi.Dispose();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double[,] Gecici = new Double[4, 4];
          
            Double teta = Convert.ToDouble(textBox1.Text);

            Tdondur[0, 0] = Math.Cos(Math.PI * teta / 180);
            Tdondur[0, 1] = -(Math.Sin(Math.PI * teta / 180));
            Tdondur[1, 0] = Math.Sin(Math.PI * teta / 180);
            Tdondur[1, 1] = Math.Cos(Math.PI * teta / 180);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Gecici[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        Gecici[i, j] += UcgenCismi[i, k] * Tdondur[k, j];
                    }
                }
            }
            Pen Klm = new Pen(Color.Brown, 2);
            Cizgi = this.CreateGraphics();
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(Gecici[0, 0]), YansimisUcgenHesaplaY(Gecici[0, 1]), YansimisUcgenHesaplaX(Gecici[1, 0]), YansimisUcgenHesaplaY(Gecici[1, 1]));
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(Gecici[1, 0]), YansimisUcgenHesaplaY(Gecici[1, 1]), YansimisUcgenHesaplaX(Gecici[2, 0]), YansimisUcgenHesaplaY(Gecici[2, 1]));
            Cizgi.DrawLine(Klm, YansimisUcgenHesaplaX(Gecici[2, 0]), YansimisUcgenHesaplaY(Gecici[2, 1]), YansimisUcgenHesaplaX(Gecici[0, 0]), YansimisUcgenHesaplaY(Gecici[0, 1]));
            Cizgi.Dispose();
        }
    }
      
}
