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
    public partial class Form3 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");

        public Form3()
        {
            InitializeComponent();
        }

        public void open1(object o)
        {
            Application.Run(new Acceuille());
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel9.Visible = true;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            guna2Panel9.Visible = false;

            if (guna2TextBox5.PasswordChar == '\0')
            {

                guna2TextBox5.PasswordChar = '*';
            }
        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" ||  guna2TextBox4.Text == "" || guna2TextBox5.Text == "" ) 
            
            { MessageBox.Show("le champs vide", "vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

               else if (guna2TextBox4.TextLength < 4)
                { MessageBox.Show("le chapms de Username doit être plus de 4 caractere", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }


                else if (guna2TextBox5.TextLength < 5)


                { MessageBox.Show("le chapms de Password doit être plus de 5 caractere", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }


            else
            {
                cn.Open();
                SqlCommand c = new SqlCommand("select * from LogIn  where Username='" + guna2TextBox4.Text + "'", cn);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {

                    MessageBox.Show("Le Username est Deja existe Essayer autre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



                }

                else
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(string.Format("insert into LogIn values('{0}','{1}','{2}','{3}')", guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox4.Text, guna2TextBox5.Text), cn);
                    rd.Close();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bien Inscrit", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cn.Close();

                    Form6 f = new Form6();
                    f.Show();
                    this.Close();
                }
                cn.Close();
                rd.Close();
            }
           
        }
    }

    }