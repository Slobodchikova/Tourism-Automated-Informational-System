using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class OtchetTransport : Form
    {
        public OtchetTransport()
        {
            InitializeComponent();
        }

        private void OtchetTransport_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "TravelDataSet.TransportWithoutId". При необходимости она может быть перемещена или удалена.
            this.TransportWithoutIdTableAdapter.Fill(this.TravelDataSet.TransportWithoutId);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transport ss = new Transport();
            ss.Show();
        }
    }
}
