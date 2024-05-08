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
    public partial class Form8 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");

        public Form8()
        {

            InitializeComponent();
        }
        public void open4(object o)
        {
            Application.Run(new Réservation());
        }
        public void open1(object o)
        {
            Application.Run(new Form1());
        }
        public void open7(object o)
        {
            Application.Run(new Voitures());
        }
        public void open5(object o)
        {
            Application.Run(new Clients());
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
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

            guna2DataGridView2.BorderStyle = BorderStyle.None;
            guna2DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            guna2DataGridView2.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView2.DefaultCellStyle.SelectionBackColor = Color.Black;
            guna2DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            guna2DataGridView2.BackgroundColor = Color.Gray;
            guna2DataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            guna2DataGridView2.EnableHeadersVisualStyles = false;
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridMarque();
            gridModele();
            comboModele();

        }
        private void gridModele()
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select IdModele,NomMarque,NomModele,AnneéModele from Modele o inner join Marque m on m.IdMarque=o.IdMarque", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            guna2DataGridView2.DataSource = dt;
            rd.Close();
            cn.Close();

        }
        private void gridMarque()
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Marque ", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(rd);
            guna2DataGridView1.DataSource = d;
            rd.Close();
            cn.Close();
        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else 
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from Marque where NomMarque='"+guna2TextBox1.Text+"'", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("La Marque   est Deja existe Essayer autre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else { rd.Close();
                SqlCommand c = new SqlCommand(string.Format("Insert into Marque Values('{0}')",guna2TextBox1.Text),cn);
                c.ExecuteNonQuery();
                MessageBox.Show("La Marque est bien Ajjouter", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                gridMarque();
                cn.Close();
                comboModele();
                cn.Close();
                }
            
            }
        }
        private void comboModele() 
        {
            cn.Close();
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Marque  ", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            gunaComboBox2.DisplayMember = "NomMarque";
            gunaComboBox2.ValueMember = "IdMarque";
            DataTable combo = new DataTable();
            combo.Load(rd);
            gunaComboBox2.DataSource = combo;
            rd.Close();
            cn.Close();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from Marque where IdMarque=" + guna2DataGridView1.SelectedRows[0].Cells[0].Value + "", cn);
                cmd.ExecuteNonQuery();
                gridMarque();
                cn.Close();
                comboModele();
                cn.Close();
            }

            catch (SqlException ex)
            {
                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir Dans la Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547)
                { MessageBox.Show("Cette Marque Est deja Utiliser dans une voiture tu n'as pas le droit de supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {

            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from Modele where NomModele='" + guna2TextBox3.Text + "'and AnneéModele='"+bunifuDatePicker1.Value.ToShortDateString()+"'", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    MessageBox.Show("Le Modele   est Deja existe Essayer autre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    rd.Close();
                    SqlCommand c = new SqlCommand(string.Format("Insert into Modele Values('{0}','{1}',{2})", guna2TextBox3.Text,bunifuDatePicker1.Value.ToShortDateString(),gunaComboBox2.SelectedValue),cn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Le Modele Bien ajjouter", "bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    gridModele();
                    cn.Close();
                }

            }
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from Modele where IdModele=" + guna2DataGridView2.SelectedRows[0].Cells[0].Value + "", cn);
                cmd.ExecuteNonQuery();
                gridModele();
            }
            catch (SqlException ex )
            {

                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir Dans la Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547)
                { MessageBox.Show("Cette Marque Est deja Utiliser dans une voiture tu n'as pas le droit de supprimer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand c = new SqlCommand(string.Format("Update Marque set NomMarque='{0}' where IdMarque= {1}", guna2TextBox1.Text, guna2DataGridView1.SelectedRows[0].Cells[0].Value), cn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("La Marque est bien Modifier", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    gridMarque();
                    cn.Close();
                    comboModele();
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 102)
                {
                    MessageBox.Show("Choisir dans le table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox3.Text == "")
                {
                    MessageBox.Show("champ est vide!!", "Vide!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand c = new SqlCommand(string.Format("Update Modele set NomModele='{0}',AnneéModele='{1}',IdMarque={2} where IdMarque= {3}", guna2TextBox3.Text,bunifuDatePicker1.Value.ToShortDateString(),gunaComboBox2.SelectedValue, guna2DataGridView2.SelectedRows[0].Cells[0].Value), cn);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Le Modele est bien Modifier", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    gridModele();
                    cn.Close();
                    
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread d = new Thread(open4);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread d = new Thread(open5);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            this.Close();
            Thread d = new Thread(open7);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
        
    }
}