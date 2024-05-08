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
    public partial class Clients : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");

        public Clients()
        {
            InitializeComponent();

            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            guna2DataGridView1.BackgroundColor = Color.Gray;
            guna2DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid();
        }

        public void open(object o)
        {
            Application.Run(new Réservation());
        }
        public void open1(object o)
        {
            Application.Run(new Form1());
        }
        public void open2(object o)
        {
            Application.Run(new Form8());
        }
        public void open3(object o)
        {
            Application.Run(new Voitures());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void grid()
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Client", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            guna2DataGridView1.DataSource = dt;
            rd.Close();
            cn.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from Client where IdClient=" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bien Supprimer", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cn.Close();
                grid();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir Dans la Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547)
                { MessageBox.Show("Le Client Est deja reserver Une Voiture Tu n'as pas le droit de supprimer","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            }
        }

        private string sex()
        {
            string s = "";

            if (gunaRadioButton1.Checked)
            {
                s = "homme";

            }

            else if (gunaRadioButton2.Checked)
            { s = "femme"; }


            return s;

        }
        private void bunifuButton7_Click(object sender, EventArgs e)
        {

            if (guna2TextBox6.Text == "" || guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "" || sex() == "")
            {
                MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("insert into Client values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", guna2TextBox6.Text, guna2TextBox1.Text, guna2TextBox2.Text, sex(), guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox5.Text), cn);
                SqlCommand c = new SqlCommand("select * from Client  where CIN='" + guna2TextBox6.Text + "'", cn);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Le CIN  est Deja existe Essayer autre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    rd.Close();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bien Ajjouter", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cn.Close();
                    grid();
                    guna2TextBox6.Text = ""; guna2TextBox1.Text = ""; guna2TextBox2.Text = ""; guna2TextBox3.Text = ""; guna2TextBox4.Text = ""; guna2TextBox5.Text = "";
                }
            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {

            try
            {
                if (guna2TextBox6.Text == "" || guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "" || sex() == "")
                {
                    MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cn.Close();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Client set CIN='{0}',NomClient='{1}',PrenomClient='{2}',Sexe='{3}',Adresse='{4}',Telephone='{5}',Email='{6}' where IdClient={7}", guna2TextBox6.Text, guna2TextBox1.Text, guna2TextBox2.Text, sex(), guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox5.Text, guna2DataGridView1.SelectedRows[0].Cells[0].Value), cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bien Modifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cn.Close();
                    grid();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir Dans la Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Client where IdClient=" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                guna2TextBox6.Text = rd[1].ToString();
                guna2TextBox1.Text = rd[2].ToString();
                guna2TextBox2.Text = rd[3].ToString();
                if (rd[4].ToString() == "homme")
                {
                    gunaRadioButton1.Checked = true;
                }
                else if (rd[4].ToString() == "femme")
                {
                    gunaRadioButton2.Checked = true;
                }
                guna2TextBox3.Text = rd[5].ToString();
                guna2TextBox4.Text = rd[6].ToString();
                guna2TextBox5.Text = rd[7].ToString();
            }
            rd.Close();
            cn.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open2);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open3);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.Show();
        }
        }
    }


