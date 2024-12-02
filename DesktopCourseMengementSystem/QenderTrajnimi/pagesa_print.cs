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
    public partial class pagesa_print : Form
    {
        public pagesa_print()
        {
            InitializeComponent();
        }

        private void pagesa_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
