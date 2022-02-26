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
    public partial class LookTransfers : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        public LookTransfers()
        {
            InitializeComponent();
            sql = "SELECT Transfers.IdTransfers as Id, Hotel.HotelName as Отель, Transfers.Number as 'Номер машины', Transfers.Class as 'Тип', Transfers.Cost as 'Стоимость'," +
"Transfers.Way as 'Путь', Transfers.TimeOfDeparture as 'Время отправления', Transfers.TimeOfArrival as 'Время прибытия'" +
"FROM Transfers join Hotel on (Transfers.IdHotel = Hotel.IdHotel) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Transport");
                dataGridView1.DataSource = ds.Tables["Transport"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transport ss = new Transport();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            sql = "SELECT Transfers.IdTransfers as Id, Hotel.HotelName as Отель, Transfers.Number as 'Номер машины', Transfers.Class as 'Тип', Transfers.Cost as 'Стоимость'," +
"Transfers.Way as 'Путь', Transfers.TimeOfDeparture as 'Время отправления', Transfers.TimeOfArrival as 'Время прибытия'" +
"FROM Transfers join Hotel on (Transfers.IdHotel = Hotel.IdHotel) WHERE Hotel.HotelName = '"+str+"'";
            if (str == "") sql = "SELECT Transfers.IdTransfers as Id, Hotel.HotelName as Отель, Transfers.Number as 'Номер машины', Transfers.Class as 'Тип', Transfers.Cost as 'Стоимость'," +
"Transfers.Way as 'Путь', Transfers.TimeOfDeparture as 'Время отправления', Transfers.TimeOfArrival as 'Время прибытия'" +
"FROM Transfers join Hotel on (Transfers.IdHotel = Hotel.IdHotel) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Transport");
                dataGridView1.DataSource = ds.Tables["Transport"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string select = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            sql = "DELETE FROM Transfers WHERE IdTransfers = " + select;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Transfer");

            }
        }
    }
}
