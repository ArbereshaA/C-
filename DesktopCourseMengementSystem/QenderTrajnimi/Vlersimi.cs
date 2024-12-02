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
    public partial class Vlersimi : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ARTAN-ABDULLA;Initial Catalog=QenderTrajnimi;Integrated Security=True");

        public Vlersimi()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            if (txtPiket.Text.Trim() == string.Empty)
            {
                con.Close();
                MessageBox.Show("Ju lutem shenoni piket");
                return;
            }
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Vlersimi VALUES(@sID,@Kurset,@Vlersimi,@DataVlersimit,@EmriProfesorit)", con);
            sqlCmd.Parameters.AddWithValue("@sID", ComsID.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Kurset", ComEmriKursit.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Vlersimi", txtPiket.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DataVlersimit", Date.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EmriProfesorit", ComLigjirusi.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vlersimi", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vlersimi");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            MessageBox.Show("Ruajtur me sukses");



        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM Vlersimi WHERE sID='" + ComsID.Text+ "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vlersimi"); 
            dataGridView1.DataSource = ds.Tables["Vlersimi"];
            MessageBox.Show("Larguat me sukses!");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM Vlersimi", con);
            daf.Fill(ds, "Vlersimi");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;

        }

        private void ndrysho_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("UPDATE Vlersimi set Kursi='" + ComEmriKursit.Text + "',EmriProfesorit='" + ComLigjirusi.Text + "',DataVlersimit='" + Date.Text + "',Vlersimi='" + txtPiket.Text + "' WHERE sID=" + ComsID.Text + "", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vlersimi");
            dataGridView1.DataSource = ds.Tables["Vlersimi"];
            MessageBox.Show("Te dhenat u ndryshuan me sukses!");
            con.Close();
            SqlDataAdapter daf = new SqlDataAdapter("SELECT * FROM Vlersimi", con);
            daf.Fill(ds, "Vlersimi");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vlersimi WHERE sID LIKE '" + txtSearch.Text + "%';", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;


        }


        private void display_data()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Vlersimi", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            con.Close();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        private void Vlersimi_Load(object sender, EventArgs e)
        {
            display_data();
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sID FRom Regjistrimi"; // Marim Id e Studentit nga tabela Regjistrimi //
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ComsID.Items.Add(dr["sID"].ToString());
            }

            DataTable Kurs = new DataTable();
            cmd.CommandText = "SELECT Kurset FROM MenaxhimiKurseve"; // Marim Emrat e Kurseve nga tabela MenaxhimiKurseve //
            cmd.ExecuteNonQuery();
            da.Fill(Kurs);
            foreach (DataRow Kurset in Kurs.Rows)
            {
                ComEmriKursit.Items.Add(Kurset["Kurset"].ToString());
            }

            DataTable Profesor = new DataTable();
            cmd.CommandText = "SELECT EmriProfesorit FROM Profesoret"; // Marim Emrat e Profesoreve nga tabela Profesoret //
            cmd.ExecuteNonQuery();
            da.Fill(Profesor);
            foreach (DataRow prof in Profesor.Rows)
            {
                ComLigjirusi.Items.Add(prof["EmriProfesorit"].ToString());

            }
            con.Close();
        }

        private void btnPërfundo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ligjeruesit prof = new Ligjeruesit();
            prof.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                ComsID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                ComEmriKursit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ComLigjirusi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Date.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtPiket.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }

        }
    }
   }

