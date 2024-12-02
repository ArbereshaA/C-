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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnKurset_Click(object sender, EventArgs e)
        {
            Menaxhimi_i_Kurseve Menaxhimi_i_kurseve = new Menaxhimi_i_Kurseve();
            Menaxhimi_i_kurseve.Show();
        }

        private void btnLigjeruesit_Click(object sender, EventArgs e)
        {
            Ligjeruesit Shenimet_Ligjeruese = new Ligjeruesit();
            Shenimet_Ligjeruese.Show();
        }

        private void btnStudenti_Click(object sender, EventArgs e)
        {
            Regjistrimi regjistrimi_kandidateve = new Regjistrimi();
            regjistrimi_kandidateve.Show();
        }

        private void btnVlersimi_Click(object sender, EventArgs e)
        {
            Vlersimi vlersimi_i_kandidateve = new Vlersimi();
            vlersimi_i_kandidateve.Show();
        }

        private void btnRezultatet_Click(object sender, EventArgs e)
        {
            Rezultatet rezultatet_e_kandidateve = new Rezultatet();
            rezultatet_e_kandidateve.Show();
        }

        private void btnPagesat_Click(object sender, EventArgs e)
        {
            Pagesat pagesat_e_rezlizuara = new Pagesat();
            pagesat_e_rezlizuara.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ky aplikacion është dizajnuar dhe implementuar në kuadër të lendes Programimi i orientuar ne objekte dhe vizuel (C#,Sql), nga Artan Abdulla dhe Bestar Zeqiri - student të Informatikes viti i dyte. \nMentor: Doc.Dr.Agon Memeti. \n\nTetove, Maj 2017");
        }

        private void btnPerfundo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        private void aboutThisAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versioni 1.0.1 - Created by Artan Abdulla & Bestar Zeqiri \n Mentor:Doc.Dr.Agon Memeti \n Tetove, Maj 2017.");
        }

        private void bacgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cd.Color;
            }
        }

        private void textPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            this.fontDialog1.ShowDialog();
            this.btnKurset.Font = this.btnLigjeruesit.Font = this.btnPagesat.Font = this.btnRezultatet.Font = this.btnVlersimi.Font = this.btnStudenti.Font = this.btnRezultatet.Font = this.btnPerfundo.Font = this.fontDialog1.Font;
            this.btnKurset.ForeColor = this.btnLigjeruesit.ForeColor = this.btnPagesat.ForeColor = this.btnRezultatet.ForeColor = this.btnVlersimi.ForeColor = this.btnStudenti.ForeColor = this.btnPerfundo.ForeColor = this.fontDialog1.Color;
        }


        private void exitFullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Normal;
            exitFullScreenToolStripMenuItem.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = true;
           
        }

        private void Home_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            exitFullScreenToolStripMenuItem.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            exitFullScreenToolStripMenuItem.Enabled = true;
            fullScreenToolStripMenuItem.Enabled = false;
        }

        private void Konverto_Click(object sender, EventArgs e)
        {
            Konvertim conv = new Konvertim();
            conv.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendFax send = new SendFax();
            send.Show();
        }
    }
}
