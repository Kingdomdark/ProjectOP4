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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = PBchar.Location.X;
            int y = PBchar.Location.Y;

            if (e.KeyCode == Keys.Right) x += 15;
            else if (e.KeyCode == Keys.Left) x -= 15;

            PBchar.Location = new Point(x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //splashbox - purpose of the game
            MessageBox.Show("VANG ALLE BLOKJES BEHALVE DE RODE EN MIS JE 3 DAN BEN JE DOOD", "About Block Catcher");
        }
    }
}
