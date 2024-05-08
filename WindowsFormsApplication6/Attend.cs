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
    public partial class Attend : Form
    {
        Thread d;
        public Attend()
        {
            InitializeComponent();
        }

        public void open(object obj)
        {
            Application.Run(new Form1());
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value==99 )
            { timer1.Stop();

            bunifuButton1.Visible = true;
            
            
            
            
            }
            guna2CircleProgressBar1.Value += 1;
            label4.Text = (int.Parse(label4.Text) + 1).ToString();


        }

        private void Form4_Load(object sender, EventArgs e)
        {

            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
            bunifuButton1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            d = new Thread(open);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();

        }
    }
}
