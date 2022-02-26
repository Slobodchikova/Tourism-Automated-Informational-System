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
    public partial class LookHotelRoom : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";

        public LookHotelRoom()
        {
            InitializeComponent();
            sql = "SELECT HotelRoom.IdHotelRoom as Id, Hotel.HotelName as Отель, HotelRoom.RoomType as Тип, HotelRoom.NumberOfBeds as 'Количество мест', HotelRoom.Cost1Day as 'Стоимость 1 ночь'," +
"HotelRoom.NameRoom as Описание FROM Hotel join HotelRoom on (hotel.IdHotel=HotelRoom.IdHotel)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "hotel");
                dataGridView1.DataSource = ds.Tables["Hotel"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
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
            string str = textBox1.Text;
            sql = "SELECT HotelRoom.IdHotelRoom as Id, Hotel.HotelName as Отель, HotelRoom.RoomType as Тип, HotelRoom.NumberOfBeds as 'Количество мест', HotelRoom.Cost1Day as 'Стоимость 1 ночь'," +
"HotelRoom.NameRoom as Описание FROM Hotel join HotelRoom on (hotel.IdHotel=HotelRoom.IdHotel) WHERE Hotel.HotelName='"+str+"'";
            if (str == "") sql = "SELECT HotelRoom.IdHotelRoom as Id, Hotel.HotelName as Отель, HotelRoom.RoomType as Тип, HotelRoom.NumberOfBeds as 'Количество мест', HotelRoom.Cost1Day as 'Стоимость 1 ночь'," +
"HotelRoom.NameRoom as Описание FROM Hotel join HotelRoom on (hotel.IdHotel=HotelRoom.IdHotel)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Hotel");
                dataGridView1.DataSource = ds.Tables["Hotel"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string select = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            sql = "DELETE FROM HotelRoom WHERE IdHotelRoom = " + select;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HotelRoom");

            }
        }
    }
}
