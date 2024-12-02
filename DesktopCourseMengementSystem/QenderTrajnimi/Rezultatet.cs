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
    public partial class Rezultatet : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");
        public Rezultatet()
        {
            InitializeComponent();
        }

        private void Rezultatet_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Vlersimi.Kursi, Vlersimi.Vlersimi, Vlersimi.DataVlersimit, Vlersimi.EmriProfesorit 
            FROM Regjistrimi INNER JOIN Vlersimi ON Regjistrimi.sID = Vlersimi.sID order BY Vlersimi.DataVlersimit";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["sID"], ListSortDirection.Ascending);
        }

        private void btnRezultatetSukses_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Vlersimi.Kursi, Vlersimi.Vlersimi, Vlersimi.DataVlersimit, Vlersimi.EmriProfesorit
            FROM Regjistrimi INNER JOIN Vlersimi ON Regjistrimi.sID = Vlersimi.sID WHERE Vlersimi.Vlersimi >= 51 ORDER BY Regjistrimi.sID";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnRezultatetPaSukses_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Vlersimi.Kursi, Vlersimi.Vlersimi, Vlersimi.DataVlersimit, Vlersimi.EmriProfesorit
            FROM Regjistrimi INNER JOIN Vlersimi ON Regjistrimi.sID = Vlersimi.sID Where Vlersimi.Vlersimi <= 50
            ORDER BY Regjistrimi.sID";
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
            string query = @"SELECT Regjistrimi.sID, Regjistrimi.Emri, Regjistrimi.Mbiemri, Vlersimi.Kursi, Vlersimi.Vlersimi, Vlersimi.DataVlersimit, Vlersimi.EmriProfesorit
            FROM Regjistrimi INNER JOIN Vlersimi ON Regjistrimi.sID = Vlersimi.sID 
            ORDER BY Regjistrimi.sID";
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
            Rezultatet_print print = new Rezultatet_print();
            print.Show();
        }

    }
}
