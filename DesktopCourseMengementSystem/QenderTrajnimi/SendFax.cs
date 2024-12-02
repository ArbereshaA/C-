using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QenderTrajnimi
{
    public partial class SendFax : Form
    {
        public SendFax()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            localhost1.fax send = new localhost1.fax();
            string answer =(send.SendTextToFax(this.textBox1.Text,this.textBox2.Text,this.textBox3.Text,this.textBox4.Text,this.textBox5.Text)).ToString();
            MessageBox.Show(answer);
        }

        private void SendFax_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }
    }
}
