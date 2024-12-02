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
    public partial class Menaxhimi_i_Kurseve : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");

        public Menaxhimi_i_Kurseve()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtEmriKursit.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Emrin e kursit!");
                con.Close();
                return;

            }
            if (txtCmimi.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Cmimin e kursit!");
                con.Close();
                return;

            }
      

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO MenaxhimiKurseve VALUES(@Kurset,@Cmimi)", con);
            sqlCmd.Parameters.AddWithValue("@Kurset", txtEmriKursit.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Cmimi", txtCmimi.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter daF = new SqlDataAdapter("SELECT * from MenaxhimiKurseve", con);
            DataSet ds = new DataSet();
            daF.Fill(ds, "MenaxhimiKurseve");
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show("Ruajtur me sukses");
            txtEmriKursit.Text = txtCmimi.Text = "";

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from MenaxhimiKurseve", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            btnDelet.Enabled = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }


        private void txtCmimi_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Ju lutem shenoni Cmimin!");
            }
        }

        private void txtEmriKursit_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ju lutem shenoni Emrin e kursit!");

            }
            con.Close();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM MenaxhimiKurseve WHERE Kurset='" + txtEmriKursit.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "MenaxhimiKurseve");
            dataGridView1.DataSource = ds.Tables["MenaxhimiKurseve"];
            MessageBox.Show("Larguat me sukses!");
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM MenaxhimiKurseve", con);
            daf.Fill(ds, "MenaxhimiKurseve");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            btnSave.Enabled = true;
            btnDelet.Enabled = false;
            txtEmriKursit.Text = txtCmimi.Text = "";


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string s = "";
            if (txtSearch.Text != "")
              {
                if (s == "") 
                    s = "([Kurset] like '" + txtSearch.Text + "%')";
                else
                    s = s + " AND ([Kurset] like '" + txtSearch.Text + "%')";
               
            }
           
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM MenaxhimiKurseve", con);
            if (s != "")
                sqlCmd.CommandText = sqlCmd.CommandText + " WHERE " + s;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "MenaxhimiKurseve");
            dataGridView1.DataSource = ds.Tables[0];
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                txtEmriKursit.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtCmimi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                btnDelet.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void brnPerditeso_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
