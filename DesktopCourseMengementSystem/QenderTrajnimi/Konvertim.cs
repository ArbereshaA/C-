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
    public partial class Konvertim : Form
    {
        public Konvertim()
        {
            InitializeComponent();
        }


        private void Konvertim_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        private void Konverto_Click(object sender, EventArgs e)
        {
            localhost.Konvertimi conv = new localhost.Konvertimi();
            this.textBox2.Text = conv.convertDenToEuro(double.Parse(textBox1.Text)).ToString();
        }

        private void konverto1_Click(object sender, EventArgs e)
        {
            localhost.Konvertimi conv = new localhost.Konvertimi();
            this.textBox4.Text = conv.convertEuroToDen(double.Parse(textBox3.Text)).ToString();
        }
    }
}
