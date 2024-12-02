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
    public partial class Regjistrimi_Print : Form
    {
        public Regjistrimi_Print()
        {
            InitializeComponent();
        }

        private void Regjistrimi_Print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Regjistrimi' table. You can move, or remove it, as needed.
            this.RegjistrimiTableAdapter.Fill(this.DataSet1.Regjistrimi);

            this.reportViewer1.RefreshReport();
        }
    }
}
