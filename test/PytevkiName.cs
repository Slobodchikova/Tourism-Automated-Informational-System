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
    public partial class PytevkiName : Form
    {
      
        string sql;
        //connection.Open();
        DataTable dt;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        public PytevkiName()
        {
            InitializeComponent();
            sql = "SELECT Traveler.LastName as Фамилия, Traveler.FirstName as Имя, Direction.Resort as Путешествие," +
               "Hotel.HotelName as Отель, Trip.Date1 as 'Дата отправления',Trip.Date2 as 'Дата возвращения', Trip.Cost 'Стоимость'" +
               "FROM Trip JOIN Traveler ON (Traveler.IdTraveler = Trip.IdTraveler) JOIN Direction ON (Direction.IdDirection = Trip.IdDirection)" +
            "JOIN Hotel ON (Hotel.IdHotel = Trip.IdDirection)";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
           sql = "SELECT Traveler.LastName as Фамилия, Traveler.FirstName as Имя, Direction.Resort as Путешествие," + 
               "Hotel.HotelName as Отель, Trip.Date1 as 'Дата отправления',Trip.Date2 as 'Дата возвращения', Trip.Cost 'Стоимость'"+ 
               "FROM Trip JOIN Traveler ON (Traveler.IdTraveler = Trip.IdTraveler) JOIN Direction ON (Direction.IdDirection = Trip.IdDirection)"+
			"JOIN Hotel ON (Hotel.IdHotel = Trip.IdDirection) WHERE Traveler.LastName = '"+name+"'";
           if (name == "") sql = "SELECT Traveler.LastName as Фамилия, Traveler.FirstName as Имя, Direction.Resort as Путешествие," +
             "Hotel.HotelName as Отель, Trip.Date1 as 'Дата отправления',Trip.Date2 as 'Дата возвращения', Trip.Cost 'Стоимость'" +
             "FROM Trip JOIN Traveler ON (Traveler.IdTraveler = Trip.IdTraveler) JOIN Direction ON (Direction.IdDirection = Trip.IdDirection)" +
          "JOIN Hotel ON (Hotel.IdHotel = Trip.IdDirection)";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               connection.Open();
               SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
               DataSet ds = new DataSet();
               adapter.Fill(ds, "Путешествия");
               dataGridView1.DataSource = ds.Tables["Путешествия"].DefaultView;
           }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client ss = new Client();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }
    }
}
