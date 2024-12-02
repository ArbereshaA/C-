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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\Arbresha\ARBRESHA;Initial Catalog=QenderTrajnimiDatabase;Integrated Security=True");
            con.Open();
            string select = "SELECT * From Useret Where username='" + this.textBox1.Text + "' AND password='" + this.textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                MessageBox.Show("You have been logeed succesfully!");
                textBox1.Text = textBox2.Text = "";
                Form frm = new Home();
                frm.Show();
              
                
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect,please try again!");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            label2.Text = "Please Enter the Username and Password to go to the \nAdmin page!";
            label5.Text = "Forgot Password?";
            label5.Font = new Font(label5.Font.Name, 8, FontStyle.Underline);
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.BorderSize = 0;
            
            
           
        }

    

           
    }
}
