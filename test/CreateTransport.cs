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
    public partial class CreateTransport : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        DataTable dt;

        public CreateTransport()
        {
            
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            sql = "SELECT * FROM Direction";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);

                this.comboBox2.DataSource = dt;
                this.comboBox2.DisplayMember = "Direction";// столбец для отображения
                this.comboBox2.ValueMember = "Resort";//столбец с id
                this.comboBox2.SelectedIndex = -1;

            }
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM Direction";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "Direction";// столбец для отображения
                this.comboBox1.ValueMember = "Resort";//столбец с id
                this.comboBox1.SelectedIndex = -1;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transport ss = new Transport();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string res, res2;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectDirection  '" + (comboBox1.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                res = string.Empty;
                while (thisReader.Read())
                {
                    res += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectDirection  '" + (comboBox2.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                res2 = string.Empty;
                while (thisReader.Read())
                {
                    res2 += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (res == "") res = "1";
            if (res2 == "") res2 = "1";
            string date = dateTimePicker1.Value.Date.ToString();
            string date2 = dateTimePicker2.Value.Date.ToString();
            sql = "INSERT INTO Transport VALUES " +
               "(" + res + ", " + res2 + ", '" + date2 + "', '" + textBox2.Text + "', '" + date + "', '" + textBox1.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Данные добавлены!");
            }
            this.Close();
            CreateTransport ss = new CreateTransport();
            ss.Show();
        }
    }
}
