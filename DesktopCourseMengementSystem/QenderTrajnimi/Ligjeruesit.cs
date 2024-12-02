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
    public partial class Ligjeruesit : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");
        public Ligjeruesit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            con.Open();
            if (txtEmriP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutem shenoni Emrin e Profesorit");
                con.Close();
                return;
            }
            if (txtTitulliAkademik.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutem shenoni Titullin Akademik te Profesorit");
                con.Close();
                return;
            }
            if (txtAdresa.Text == string.Empty)
            {
                MessageBox.Show("Ju lutem shenoni Adresen e Profesorit");
                con.Close();
                return;
            }
            if (txtTelefoni.Text == string.Empty)
            {
                MessageBox.Show("Ju lutem shenoni Numrin e Telefonit");
                con.Close();
                return;
            }


            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Profesoret VALUES(@EmriProfesorit,@TitulliAkademik,@Telefoni,@Adresa)", con);
            sqlCmd.Parameters.AddWithValue("@EmriProfesorit", txtEmriP.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@TitulliAkademik",txtTitulliAkademik.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Telefoni", txtTelefoni.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Adresa", txtAdresa.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter daF = new SqlDataAdapter("SELECT * From Profesoret", con);
            DataSet ds = new DataSet();
            daF.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show("Ruajtur me Sukses!");
            txtEmriP.Text = txtTitulliAkademik.Text = txtAdresa.Text = txtTelefoni.Text = "";
            
        }
        private void display_data()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Profesoret", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            txtID.ReadOnly = true;
            btnDelet.Enabled = false;
            btnPerditeso.Enabled = false;
            display_data();

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM Profesoret WHERE EmriProfesorit='" + txtEmriP.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables["Profesoret"];
            MessageBox.Show("Larguat me Sukses!");
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM Profesoret", con);
            daf.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            txtEmriP.Text = txtTitulliAkademik.Text = txtAdresa.Text = txtTelefoni.Text = txtID.Text = "";
            btnSave.Enabled = true;
            btnPerditeso.Enabled = false;
            btnDelet.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtEmriP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtTitulliAkademik.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTelefoni.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtAdresa.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                btnDelet.Enabled = true;
                btnPerditeso.Enabled = true;
                btnSave.Enabled = false;
                
            }

        }

        private void btnPerditeso_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE Profesoret set EmriProfesorit='" + txtEmriP.Text + "',TitulliAkademik='" + txtTitulliAkademik.Text + "',Telefoni='" + txtTelefoni.Text + "',Adresa='" + txtAdresa.Text + "' WHERE ID=" + txtID.Text + "", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables["Profesoret"];
            MessageBox.Show("Te dhenat u ndryshuan me sukses!");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * from Profesoret", con);
            daf.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables[0];
            txtEmriP.Text = txtTitulliAkademik.Text = txtTelefoni.Text = txtID.Text = txtAdresa.Text =  "";
            btnSave.Enabled = true;
            btnDelet.Enabled = false;
            btnPerditeso.Enabled = false;
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           string s = "";
            if (txtSearch.Text != "")
              {
                if (s == "") 
                    s = "([EmriProfesorit] like '" + txtSearch.Text + "%')";
                else
                    s = s + " AND ([EmriProfesorit] like '" + txtSearch.Text + "%')";
            }
             
           
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Profesoret", con);
            if (s != "")
            sqlCmd.CommandText = sqlCmd.CommandText + " WHERE " + s;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
