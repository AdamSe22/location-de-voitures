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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-RK7CV6U;Initial Catalog=LocationV;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        public void open(object o)
        {
            Application.Run(new Clients());
        }
        public void open1(object o)
        {
            Application.Run(new Réservation());
        }
        public void open2(object o)
        {
            Application.Run(new Form8());
        }
        public void open3(object o)
        {
            Application.Run(new Voitures());
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select  CIN,NomClient, PrenomClient from Client", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            guna2DataGridView1.DataSource = dt;
            

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
            rd.Close();
            SqlCommand c = new SqlCommand("select count(IdVoiture) from Voiture",cn);
            SqlDataReader r = c.ExecuteReader();
            if (r.Read())
            { label1.Text = r[0].ToString(); }
            r.Close();
            SqlCommand s = new SqlCommand("select count(IdClient ) from Client", cn);
            SqlDataReader ss = s.ExecuteReader();
            if (ss.Read())
            { label19.Text = ss[0].ToString(); }

            ss.Close();
            r.Close();

            SqlCommand cm = new SqlCommand("select DateDebut,DateFin,NomClient,PrenomClient,Matricule , NomMarque,NomModele,PrixParJour,ncarburant as Carburant  from Voiture v inner join Modele m on m.IdModele=v.IdModele inner join Marque mm on mm.IdMarque=v.IdMarque inner join Carburant ca on ca.Idc=v.Idc inner join  Reservation r on v.IdVoiture=r.IdVoiture inner join Client c on r.IdClient=c.IdClient where r.DateFin >='" + DateTime.Now + "'", cn);
            SqlDataReader read = cm.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(read);
            guna2DataGridView2.DataSource = d;

            read.Close();
            cn.Close();
            Attend a = new Attend();
            a.Close();



            
            

        }

        private void gunaGradient2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open1);
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

        private void gunaGradient2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread d = new Thread(open3);
            d.SetApartmentState(ApartmentState.STA);
            d.Start();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
