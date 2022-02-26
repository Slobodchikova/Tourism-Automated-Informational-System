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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Hide();
            AddPerson ss = new AddPerson();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PytevkiName ss = new PytevkiName();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PytevkaCreate ss = new PytevkaCreate();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RepClient ss = new RepClient();
            ss.Show();
        }
    }
}
