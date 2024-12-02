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
    public partial class Qytetet : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");
        public Qytetet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Qytetet VALUES(@EmriQytetit)", con);
            sqlCmd.Parameters.AddWithValue("@qID", 0);
            sqlCmd.Parameters.AddWithValue("@EmriQytetit", txtEmriQytetit.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            SqlDataAdapter daF = new SqlDataAdapter("SELECT * from Qytetet", con);
            DataSet ds = new DataSet();
            daF.Fill(ds, "Qytetet");
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show("Ruajtur me sukses");
            txtID.Text = txtEmriQytetit.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtEmriQytetit.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                btnDelet.Enabled = true;
                btnSave.Enabled = false;
                
            }

        }
        private void display_data()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from Qytetet", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            btnDelet.Enabled = false;
            display_data();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM Qytetet WHERE EmriQytetit='" + txtEmriQytetit.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Qytetet");
            dataGridView1.DataSource = ds.Tables["Qytetet"];
            MessageBox.Show("Larguat me sukses!");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM Qytetet", con);
            daf.Fill(ds, "Qytetet");
            dataGridView1.DataSource = ds.Tables[0];
            txtID.Text = txtEmriQytetit.Text = "";
            btnDelet.Enabled = false;
            btnSave.Enabled = true;
          
        }

        private void brnPerditeso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
