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
    public partial class LookHotel : Form
    {
        string sql;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";

        public LookHotel()
        {
            InitializeComponent();
            sql = "SELECT Hotel.IdHotel as Id, Direction.Resort as 'Направление', Hotel.HotelName as 'Название', Hotel.Rating as 'Рейтинг', Hotel.[Address] as 'Адрес'" +
"FROM Direction join Hotel on (Direction.IdDirection=Hotel.IdDirection)";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hotel ss = new Hotel();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            sql = "SELECT Hotel.IdHotel as Id, Direction.Resort as 'Направление', Hotel.HotelName as 'Название', Hotel.Rating as 'Рейтинг', Hotel.[Address] as 'Адрес'" +
"FROM Direction join Hotel on (Direction.IdDirection=Hotel.IdDirection) WHERE Direction.Resort ='"+str+"'";
            if (str == "") sql = "SELECT Hotel.IdHotel as Id, Direction.Resort as 'Направление', Hotel.HotelName as 'Название', Hotel.Rating as 'Рейтинг', Hotel.[Address] as 'Адрес'" +
"FROM Direction join Hotel on (Direction.IdDirection=Hotel.IdDirection)";
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
            sql = "DELETE FROM Hotel WHERE IdHotel = " + select;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Hotel");

            }
        }
    }
}
