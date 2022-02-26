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
    public partial class RepClient : Form
    {
        public RepClient()
        {
            InitializeComponent();
        }

        private void RepClient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "TravelDataSet.Traveler". При необходимости она может быть перемещена или удалена.
            this.TravelerTableAdapter.Fill(this.TravelDataSet.Traveler);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client ss = new Client();
            ss.Show();
        }
    }
}
