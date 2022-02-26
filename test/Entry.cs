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
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Password f = new Password();
            f.Show();
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InfoAbout f = new InfoAbout();
            f.Show();
            
        }

        private void Entry_Load(object sender, EventArgs e)
        {

        }
    }
}
