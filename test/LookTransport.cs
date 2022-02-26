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
    public partial class LookTransport : Form
    {
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        string sql;

        public LookTransport()
        {
            InitializeComponent();
            sql = "Select Transport.IdTransport as Id, Direction.Resort as Куда, Direction2.Resort as Откуда, Transport.DateOfDeparture as 'Дата вылета', Transport.TimeOfDeparture as 'Время вылета', Transport.DateOfArrival as 'Дата вылета', Transport.TimeOfArrival as 'Время вылета'," +
 "Transport.Company as 'Компания', Transport.Cost as 'Cтоимость' FROM Direction join Transport on (Direction.IdDirection = Transport.IdDirectionWhere) join Direction2 on (Direction2.IdDirection = Transport.IdDirectionFrom)";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LookTransport_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "travelDataSet.Transport". При необходимости она может быть перемещена или удалена.
            this.transportTableAdapter.Fill(this.travelDataSet.Transport);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            sql = "Select Transport.IdTransport as Id, Direction.Resort as Куда, Direction2.Resort as Откуда, Transport.DateOfDeparture as 'Дата вылета', Transport.TimeOfDeparture as 'Время вылета', Transport.DateOfArrival as 'Дата вылета', Transport.TimeOfArrival as 'Время вылета'," +
"Transport.Company as 'Компания', Transport.Cost as 'Cтоимость' FROM Direction join Transport on (Direction.IdDirection = Transport.IdDirectionWhere) join Direction2 on (Direction2.IdDirection = Transport.IdDirectionFrom)"+
" WHERE Transport.Company = '"+ str +"'";
            if (str == "") sql = "Select Transport.IdTransport as Id, Direction.Resort as Куда, Direction2.Resort as Откуда, Transport.DateOfDeparture as 'Дата вылета', Transport.TimeOfDeparture as 'Время вылета', Transport.DateOfArrival as 'Дата вылета', Transport.TimeOfArrival as 'Время вылета'," +
  "Transport.Company as 'Компания', Transport.Cost as 'Cтоимость' FROM Direction join Transport on (Direction.IdDirection = Transport.IdDirectionWhere) join Direction2 on (Direction2.IdDirection = Transport.IdDirectionFrom)";
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transport ss = new Transport();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string select = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            sql = "DELETE FROM Transport WHERE IdTransport = "+select;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Transport");
                
            }
        }
    }
}
