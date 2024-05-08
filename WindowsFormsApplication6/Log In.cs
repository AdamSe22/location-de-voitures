using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace WindowsFormsApplication6
{
    public partial class Form6 : Form
    {
        Thread d;
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-RK7CV6U;Initial Catalog=locationV;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
        }
        public void opne(object o)
        {
            Application.Run(new Attend());
        }
        public void open1(object o)
        {
            Application.Run(new Acceuille());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            

            if (guna2TextBox5.PasswordChar == '\0')
            {

                guna2TextBox5.PasswordChar = '*';
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            cn.Close();
             cn.Open();
                SqlCommand c = new SqlCommand("select * from LogIn where Username='" + guna2TextBox4.Text + "'and Password='"+guna2TextBox5.Text+"'", cn);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    this.Close();
                    d = new Thread(opne);
                    d.SetApartmentState(ApartmentState.STA);
                    d.Start();
                }
                else { MessageBox.Show("Username or Password uncorrect", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); guna2TextBox5.Clear(); }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }
    }
}
