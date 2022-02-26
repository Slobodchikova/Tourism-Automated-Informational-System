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
    public partial class HotelRoomAdd : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        DataTable dt;

        public HotelRoomAdd()
        {
            InitializeComponent();
            sql = "SELECT * FROM Hotel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);

                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "Hotel";// столбец для отображения
                this.comboBox1.ValueMember = "HotelName";//столбец с id
                this.comboBox1.SelectedIndex = -1;

            }
        }

        private void HotelRoomAdd_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hotel ss = new Hotel();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string res;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectHotel  '" + (comboBox1.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                res = string.Empty;
                while (thisReader.Read())
                {
                    res += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (res == "") res = "1";
            sql = "INSERT INTO HotelRoom (IdHotel, RoomType, NumberOfBeds, Cost1Day) VALUES " +
              "(" + res + ", '" + textBox1.Text + "', " + textBox2.Text + ", " + textBox3.Text+")" ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Данные добавлены!");
            }
            this.Close();
            HotelRoomAdd ss = new HotelRoomAdd();
            ss.Show();
        }
    }
}
