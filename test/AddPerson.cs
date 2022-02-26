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
    public partial class AddPerson : Form
    {

        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        DataTable dt;
        public AddPerson()
        {
            InitializeComponent();
            sql = "SELECT * FROM Traveler";
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client ss = new Client();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            sql = "INSERT INTO Traveler (LastName, FirstName, MiddlName, Passport, Phone, Imeil, Birth_date)" +
            "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "' , '" + dateTimePicker1.Text + "')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                
                dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Данные добавлены!");
            }
            this.Close();
            AddPerson ss = new AddPerson();
            ss.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PytevkaCreate ss = new PytevkaCreate();
            ss.Show();
        }
    }
}
