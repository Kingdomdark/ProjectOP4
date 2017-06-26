using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //splashbox - purpose of the game
            MessageBox.Show("VANG ALLE BLOKJES BEHALVE DE RODE EN MIS JE 3 DAN BEN JE DOOD", "About Block Catcher");
        }
    }
}
