using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace test
{
    public partial class Direction : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        DataTable dt;
        public Direction()
        {
            InitializeComponent();
            sql = "SELECT * FROM Direction";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin ss = new admin();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO Direction" +
            "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox5.Text + ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Данные добавлены!");
            }
            this.Close();
           Direction ss = new Direction();
            ss.Show();
        }
    }
}
