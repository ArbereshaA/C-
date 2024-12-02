using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QenderTrajnimi
{
    public partial class Pagesat : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");
        public Pagesat()
        {
            InitializeComponent();
        }

        private void Pagesat_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Regjistrimi.Kursi,Regjistrimi.Pagesa, MenaxhimiKurseve.Cmimi
            FROM Regjistrimi INNER JOIN MenaxhimiKurseve ON Regjistrimi.Kursi = MenaxhimiKurseve.Kurset";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        private void btnPagesatPerfunduara_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Regjistrimi.Kursi, Regjistrimi.Pagesa, MenaxhimiKurseve.Cmimi
            FROM Regjistrimi INNER JOIN MenaxhimiKurseve ON Regjistrimi.Kursi = MenaxhimiKurseve.Kurset WHERE Regjistrimi.Pagesa = MenaxhimiKurseve.Cmimi";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnBorxhi_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID , Regjistrimi.Emri , Regjistrimi.Mbiemri, Regjistrimi.Kursi, Regjistrimi.Pagesa, MenaxhimiKurseve.Cmimi
            FROM Regjistrimi INNER JOIN MenaxhimiKurseve ON Regjistrimi.Kursi = MenaxhimiKurseve.Kurset WHERE Regjistrimi.Pagesa < MenaxhimiKurseve.Cmimi";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Regjistrimi.Kursi, Regjistrimi.Pagesa, MenaxhimiKurseve.Cmimi
            FROM Regjistrimi INNER JOIN MenaxhimiKurseve  ON Regjistrimi.Kursi = MenaxhimiKurseve.Kurset ORDER BY sID";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnPerfundo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagesa_print print = new pagesa_print();
            print.Show();
        }


    }
}
