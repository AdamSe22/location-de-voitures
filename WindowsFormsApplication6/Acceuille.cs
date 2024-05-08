using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication6
{
    public partial class Acceuille : Form
    {
        Thread d;
        Thread a;
        public Acceuille()
        {
            InitializeComponent();
        }
        public void opne(object o)
        {
            Application.Run(new Form6());
        }

        public void open(object o)
        {
            Application.Run(new Form3());
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            this.Close();
            d = new Thread(opne);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            a = new Thread(open);
            a.SetApartmentState(ApartmentState.STA);
            a.Start();
        }

        private void Acceuille_Load(object sender, EventArgs e)
        {

        }
    }
}
