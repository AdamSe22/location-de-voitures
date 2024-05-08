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
    public partial class Voitures : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");

        public Voitures()
        {
            InitializeComponent();
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
            Application.Run(new Clients());
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void combo2()
        { 
            cn.Close();
        cn.Open();
            SqlCommand cmd=new SqlCommand("select * from Carburant",cn);
            SqlDataReader rd = cmd.ExecuteReader();
            gunaComboBox3.DisplayMember = "nCarburant";
            gunaComboBox3.ValueMember = "IdC";
            DataTable d = new DataTable();
            d.Load(rd);
            gunaComboBox3.DataSource = d;
            
            rd.Close();
            cn.Close();
            


        }
       
        private void Form7_Load(object sender, EventArgs e)
        {
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
            combo();
            combo2();
            
            

        }
        private void grid()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select IdVoiture,Matricule , NomMarque,NomModele,PrixParJour,ncarburant as Carburant , Puissance  from Voiture v inner join Modele m on m.IdModele=v.IdModele inner join Marque mm on mm.IdMarque=v.IdMarque inner join Carburant c on c.Idc=v.Idc", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            guna2DataGridView1.DataSource = dt;
            rd.Close();
            cn.Close();
        }
        private void combo() 
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Marque ", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            gunaComboBox1.DisplayMember = "NomMarque";
            gunaComboBox1.ValueMember = "IdMarque";
            DataTable dt = new DataTable();
            dt.Load(rd);
            gunaComboBox1.DataSource = dt;
            rd.Close();
            cn.Close();
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Modele a inner join Marque m on a.IdMarque=m.IdMarque where m.IdMarque ="+gunaComboBox1.SelectedValue+"", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            gunaComboBox2.DisplayMember = "NomModele";
            gunaComboBox2.ValueMember = "IdModele";
            DataTable dt = new DataTable();
            dt.Load(rd);
            gunaComboBox2.DataSource = dt;
            rd.Close();
            cn.Close();
        
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
            {
                MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("insert into Voiture values('{0}',{1},{2},{3},'{4}',{5})", guna2TextBox1.Text, gunaComboBox1.SelectedValue, gunaComboBox2.SelectedValue, guna2TextBox2.Text, guna2TextBox3.Text+"CV", gunaComboBox3.SelectedValue), cn);
                SqlCommand c = new SqlCommand("select * from Voiture  where Matricule='" + guna2TextBox1.Text + "'", cn);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Le Matricule  est Deja existe Essayer autre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    rd.Close();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bien Ajjouter", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cn.Close();
                    grid();
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from Voiture where IdVoiture=" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "", cn);
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
                { MessageBox.Show("Cette Voiture Est deja reserver tu n'as pas  le droit de supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            }
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {

            try
            {
                if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
                {
                    MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cn.Close();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("update Voiture set Matricule='{0}',IdMarque={1},IdModele={2},PrixParJour={3},Puissance='{4}',idC={5} where IdVoiture={6}", guna2TextBox1.Text, gunaComboBox1.SelectedValue, gunaComboBox2.SelectedValue, guna2TextBox2.Text, guna2TextBox3.Text+"CV", gunaComboBox3.SelectedValue, guna2DataGridView1.SelectedRows[0].Cells[0].Value), cn);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
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

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open3);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open2);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select Matricule , NomMarque,NomModele,PrixParJour,ncarburant as Carburant  from Voiture v inner join Modele m on m.IdModele=v.IdModele inner join Marque mm on mm.IdMarque=v.IdMarque inner join Carburant c on c.Idc=v.Idc  where Matricule='" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "'", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                
                guna2TextBox1.Text = rd[0].ToString();
                gunaComboBox1.Text = rd[1].ToString();
                guna2TextBox2.Text = rd[2].ToString();
                guna2TextBox3.Text = rd[3].ToString();
                gunaComboBox2.Text = rd[4].ToString();
                gunaComboBox3.Text = rd[5].ToString();

            }
            rd.Close();
            cn.Close();
        }
    }
}
