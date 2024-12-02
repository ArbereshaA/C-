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
    public partial class Regjistrimi : Form
    {
        string Gjinia;
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");
 
        public Regjistrimi()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtEmri.Text.Trim()  == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Emrin e Kandidatit!");
                con.Close();
                return;
            }
            if (txtMbiemri.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Mbiemrin e Kandidatit!");
                con.Close();
                return;
            }
            if (!RMashkull.Checked == true && !RFemer.Checked == true)
            {
                MessageBox.Show("Ju lutem zgjidhni Gjinine");
                con.Close();
                return;
            }

            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Adresen e Kandidatit!");
                con.Close();
                return;

            }
            if (txtTel.Text == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni numrin e telefonit te Kandidatit!");
                con.Close();
                return;
            }
            if (txtPagesa.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ju lutemi,shenoni Pagesen!");
                con.Close();
                return;

            }
           
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Regjistrimi VALUES(@Emri,@Mbiemri,@Gjinia,@Qyteti,@Adresa,@Telefoni,@Kursi,@Data,@Pagesa)", con);
            sqlCmd.Parameters.AddWithValue("@Emri", txtEmri.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Mbiemri", txtMbiemri.Text.Trim());

            if (RMashkull.Checked)
            {
                sqlCmd.Parameters.AddWithValue("@Gjinia", RMashkull.Text);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@Gjinia", RFemer.Text);
            }
      
            sqlCmd.Parameters.AddWithValue("@Qyteti",ComQyteti.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Adresa",txtAddress.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Telefoni", txtTel.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Kursi", ComKursi.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Data", Data.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Pagesa", txtPagesa.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            SqlDataAdapter daF = new SqlDataAdapter("SELECT * FROM Regjistrimi", con);
            DataSet ds = new DataSet();
            con.Close();
            daF.Fill(ds, "Regjistrimi");
            dataGridView1.DataSource = ds.Tables[0];
            MessageBox.Show("Ruajtur me sukses");
            txtEmri.Text = txtMbiemri.Text = txtPagesa.Text = txtTel.Text = txtAddress.Text = txtsID.Text = Cmimi.Text = "";
            
            
        }
        private void display_data()
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * from Regjistrimi", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

   

        private void btnDelet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM Regjistrimi WHERE Emri='" + txtEmri.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Regjistrimi");
            dataGridView1.DataSource = ds.Tables["Regjistrimi"];
            MessageBox.Show("Larguat me sukses!");
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM Regjistrimi", con);
            daf.Fill(ds, "Regjistrimi");
            dataGridView1.DataSource = ds.Tables[0];
            txtEmri.Text = txtMbiemri.Text = txtPagesa.Text = txtTel.Text = txtAddress.Text = txtsID.Text = Cmimi.Text = "";
            btnDelet.Enabled = false;
            perditeso.Enabled = false;
            btnSave.Enabled = true;
            con.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txtsID.ReadOnly = true;
            Cmimi.ReadOnly = true;
            btnDelet.Enabled = false;
            perditeso.Enabled = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            display_data();

            ComKursi.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Kurset FROM MenaxhimiKurseve";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
             SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ComKursi.Items.Add(dr["Kurset"].ToString());
            }

            ComQyteti.Items.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EmriQytetit FROM Qytetet";
            cmd.ExecuteNonQuery();
            DataTable Qytetet = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(Qytetet);
            foreach (DataRow Qytet in Qytetet.Rows)
            {
                ComQyteti.Items.Add(Qytet["EmriQytetit"].ToString());
            }
            con.Close();
        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmri.Text = txtMbiemri.Text = txtPagesa.Text = txtTel.Text = txtAddress.Text = txtsID.Text = Cmimi.Text = "";
            btnSave.Enabled = true;
            perditeso.Enabled = false;
            btnDelet.Enabled = false;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                txtsID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtEmri.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtMbiemri.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Gjinia = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                ComQyteti.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtTel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                ComKursi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                Data.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtPagesa.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                btnDelet.Enabled = true;
                perditeso.Enabled = true;
                btnSave.Enabled = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE Regjistrimi set Emri='" + txtEmri.Text + "',Mbiemri='" + txtMbiemri.Text + "',Gjinia='" + Gjinia + "',Qyteti='" + ComQyteti.Text +"',Adresa='" + txtAddress.Text + "',Telefoni='" + txtTel.Text + "',Kursi='" + ComKursi.Text + "',Pagesa='" +txtPagesa.Text + "' WHERE sID=" + txtsID.Text + "", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Profesoret");
            dataGridView1.DataSource = ds.Tables["Regjistrimi"];
            MessageBox.Show("Te dhenat u ndryshuan me sukses!");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * from Regjistrimi", con);
            daf.Fill(ds, "Regjistrimi");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Menaxhimi_i_Kurseve Menaxhimi_i_kurseve = new Menaxhimi_i_Kurseve();
            Menaxhimi_i_kurseve.Show();
            this.Close();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string s = "";
            if (txtSearch.Text != "")  {
                if (s == "")
                    s = "([Emri] like '" + txtSearch.Text + "%')";
                else
                    s = s + " AND ([Emri] like '" + txtSearch.Text + "%')";
            }

            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Regjistrimi", con);
            if (s != "")
            sqlCmd.CommandText = sqlCmd.CommandText + " WHERE " + s;
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Regjistrimi");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnPerfundo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT COUNT(Regjistrimi.Gjinia) AS Nr_Meshkuj
            FROM Regjistrimi WHERE Gjinia = 'Mashkull'";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void btn_femer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT COUNT(Regjistrimi.Gjinia) AS Nr_Femrave
            FROM Regjistrimi WHERE Gjinia = 'Femër'";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

   
        private void Total_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = @"SELECT COUNT(Regjistrimi.Gjinia) AS Nr_Total
            FROM Regjistrimi";
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Qytetet Qytetet = new Qytetet();
            Qytetet.Show();
            this.Close();
        }

        private void ComKursi_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Cmimi From MenaxhimiKurseve Where Kurset='" + ComKursi.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows) {
            Cmimi.Text = dr["Cmimi"].ToString();

            }
            con.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regjistrimi_Print Print = new Regjistrimi_Print();
            Print.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
