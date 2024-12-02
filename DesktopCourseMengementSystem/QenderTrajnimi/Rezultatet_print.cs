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
    public partial class Rezultatet_print : Form
    {
        public Rezultatet_print()
        {
            InitializeComponent();
        }

        private void Rezultatet_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
