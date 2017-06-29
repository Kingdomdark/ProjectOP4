using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication4
{


    public partial class Form1 : Form
    {

        public int drop_speed = 5;
        public int score = 0;
        static Random _r = new Random();

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = PBchar.Location.X;
            int y = PBchar.Location.Y;

            if (PBchar.Right + (PBchar.Width / 3) < Form1.ActiveForm.Width)
            {
                if (e.KeyCode == Keys.Right) x += 15;
            }
            if (PBchar.Left > 0)
            {
                if (e.KeyCode == Keys.Left) x -= 15;
            }

            PBchar.Location = new Point(x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //splashbox - purpose of the game
            MessageBox.Show("VANG ALLE BLOKJES BEHALVE DE RODE EN MIS JE 3 DAN BEN JE DOOD", "About Block Catcher");
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PbBlock.Top += drop_speed;
            int ground = PBchar.Top + PBchar.Height - 45;
            if (PbBlock.Top > ground)
            {
                score--;
                PbBlock.Top = 0;
                drop_speed += 1;

                PbBlock.Top = 0;
                try
                {
                    PbBlock.Left = _r.Next(0, Form1.ActiveForm.Width - PbBlock.Width);
                }
                catch (Exception ex) { String s = ex.ToString();
                }
                }
            if (PbBlock.Bounds.IntersectsWith(PBchar.Bounds))
            {
                score++;
                PbBlock.Top = 0;
                drop_speed += 1;
                    try
                    {
                        PbBlock.Left = _r.Next(0, Form1.ActiveForm.Width - PbBlock.Width);
                    }
                    catch (Exception ex) { String s = ex.ToString(); }
                }
                }
            }
        }




