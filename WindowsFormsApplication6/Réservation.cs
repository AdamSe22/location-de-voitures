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
    public partial class Réservation : Form
    {
        public Réservation()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");

        public void open(object o)
        {
            Application.Run(new Clients());
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


        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress2_ProgressChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
            
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            label12.Visible = false;
            guna2TextBox5.Visible = false;
            guna2TextBox6.Visible = false;
            /*grid view*/

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
            combo1();
            combo2();


        }

        public void grid()
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select IdReservation, r.DateDebut,r.DateFin,c.NomClient,c.PrenomClient,c.CIN,v.Matricule,NomMarque , NomModele from Reservation r inner join Client c  on c.IdClient=r.IdClient inner join Voiture v on v.IdVoiture=r.IdVoiture inner join Modele m on m.IdModele=v.IdModele inner join Marque mm on mm.IdMarque=v.IdMarque", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd)
                ;
            guna2DataGridView1.DataSource = dt;
            rd.Close();
            cn.Close();
        }
        public void combo1() 
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Voiture", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            
            DataTable d = new DataTable();
            d.Load(rd);
            gunaComboBox2.DisplayMember = "Matricule";
            gunaComboBox2.ValueMember = "IdVoiture";

            gunaComboBox2.DataSource = d;
            rd.Close();
            cn.Close();


        }
        public void combo2()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Client  ", cn);
            SqlDataReader rd = cmd.ExecuteReader();

            DataTable d = new DataTable();
            d.Load(rd);
            gunaComboBox1.DisplayMember = "PrenomClient";
            gunaComboBox1.ValueMember = "IdClient";

            gunaComboBox1.DataSource = d;
            rd.Close();
        
        }
        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            
            label10.Visible = true;
            label12.Visible = true;
            guna2TextBox5.Visible = true;
            guna2TextBox6.Visible = true;



            guna2TextBox5.Text = (bunifuDatePicker2.Value - bunifuDatePicker1.Value).ToString("dd")+"Jour(S)";
            prix();

        }
        public void prix() 
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select PrixParJour from Voiture where Matricule='"+gunaComboBox2.Text+"'",cn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                
               string s= rd[0].ToString();
               int a = int.Parse(s);
               string aa = (bunifuDatePicker2.Value - bunifuDatePicker1.Value).ToString("dd");

               guna2TextBox6.Text = (a * int.Parse(aa)).ToString()+"DH";
            }
            cn.Close();
        
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select Telephone , Email from Client where IdClient="+gunaComboBox1.SelectedValue+"",cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            { guna2TextBox1.Text = rd[0].ToString();
            guna2TextBox2.Text = rd[1].ToString();
            }
            rd.Close();
            cn.Close();
        
        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select NomMarque , NomModele from Voiture v inner join Modele m on m.IdModele=v.IdModele inner join Marque mm on mm.IdMarque=v.IdMarque where Matricule='" + gunaComboBox2.Text + "'", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                guna2TextBox3.Text = rd[0].ToString();
                guna2TextBox4.Text = rd[1].ToString();
            }
            rd.Close();
            cn.Close();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            if ( guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "" )
            {
                MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("insert into Reservation values('{0}','{1}',{2},{3})", bunifuDatePicker1.Value.ToShortDateString(), bunifuDatePicker2.Value.ToShortDateString(), gunaComboBox1.SelectedValue, gunaComboBox2.SelectedValue), cn);
                SqlCommand c = new SqlCommand("select IdVoiture from Reservation where DateDebut >= '"+bunifuDatePicker1.Value+"' and DateFin <='"+bunifuDatePicker2.Value+"' and IdVoiture="+gunaComboBox2.SelectedValue+"", cn);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("La voiture est deja reserver ", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    rd.Close();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bien Ajjouter", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grid();
                    cn.Close();
                }
            }
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("Delete from Reservation where IdReservation=" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "", cn);
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
            }
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("Update Reservation set DateDebut='{0}',DateFin='{1}',IdClient={2},IdVoiture={3} where IdReservation={4}", bunifuDatePicker1.Value.ToShortDateString(), bunifuDatePicker2.Value.ToShortDateString(), gunaComboBox1.SelectedValue, gunaComboBox2.SelectedValue, guna2DataGridView1.SelectedRows[0].Cells[0].Value), cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bien Modifier", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grid();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir Dans la Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open3);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open2);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
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
