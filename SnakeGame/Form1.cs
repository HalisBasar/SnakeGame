using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();
        string yon = "right";
        private void label3_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            panelTemizle();
            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);

            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);
            timer1.Start();
            elmaOlustur();
        }

        void carpismaKontrol()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible = true;
                    label4.Text = "KAYBETTİNİZ!";
                    timer1.Stop();
                }
            }
        }

        void panelTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible = false;

        }

        void puanKontrol()
        {
            int puan = int.Parse(label2.Text);
            if (puan > 3800)
            {
                label4.Visible = true;
                label4.Text = "KAZANDINIZ!";
                timer1.Stop();
                
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            elmaYedimi();
            hareket();
            carpismaKontrol();
            puanKontrol();

            switch (yon)
            {
                case "right":
                    if (locX < 580)
                        locX += 20;
                    else
                    {
                        locX = 0;
                    }
                    break;
                case "left":
                    if (locX > 0)
                        locX -= 20;
                    else
                    {
                        locX = 580;
                    }
                    break;
                case "up":
                    if (locY > 0)
                        locY -= 20;
                    else
                    {
                        locY = 580;
                    }
                    break;
                case "down":
                    if (locY < 580)
                        locY += 20;
                    else
                    {
                        locY = 0;
                    }
                    break;

                default:
                    break;
            }
            //if (yon == "right")
            //{
            //    if (locX < 580)
            //        locX += 20;
            //    else
            //    {
            //        locX = 0;
            //    }                

            //}

            //if (yon == "sol")
            //{
            //    if (locX > 0)
            //        locX -= 20;
            //    else
            //    {
            //        locX = 580;
            //    }
            //}

            //if (yon == "aşağı")
            //{
            //    if (locY < 580)
            //        locY += 20;
            //    else
            //    {
            //        locY = 0;
            //    }               
            //}

            //if (yon == "yukarı")
            //{
            //    if (locY > 0)
            //        locY -= 20;
            //    else
            //    {
            //        locY = 580;
            //    }
            //}
            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && yon != "left")
            {
                yon = "right";
            }
            if (e.KeyCode == Keys.Left && yon != "right")
            {
                yon = "left";
            }
            if (e.KeyCode == Keys.Up && yon != "down")
            {
                yon = "up";
            }
            if (e.KeyCode == Keys.Down && yon != "up")
            {
                yon = "down";
            }
        }

        private void elmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;
            elma.Size = new Size(20, 20);
            elma.BackColor = Color.Yellow;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }

        void elmaYedimi()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 50;
                label2.Text = puan.ToString();
                elmaOlustur();
                parcaEkle();
            }
        }
        void parcaEkle()
        {
            Panel ekParca = new Panel();
            ekParca.Size = new Size(20, 20);
            ekParca.BackColor = Color.Gray;
            yilan.Add(ekParca);
            panel1.Controls.Add(ekParca);

        }

        void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }
    }
}
