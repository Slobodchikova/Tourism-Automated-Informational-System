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
using System.Data.OleDb;

namespace test
{
    public partial class PytevkaCreate : Form
    {
        string sql;
        //connection.Open();
        DataTable dt;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";
        DateTime end;
        
        public PytevkaCreate()
        {
            InitializeComponent();
            sql = "SELECT * FROM Traveler";
            //this.WindowState = FormWindowState.Maximized;
            textBox1.Text = "7";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "Traveler";// столбец для отображения
                this.comboBox1.ValueMember = "LastName";//столбец с id
                this.comboBox1.SelectedIndex = -1;
              
            }
        }


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM Direction";
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            //this.WindowState = FormWindowState.Maximized;
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

        private void PytevkaCreate_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client ss = new Client();
            ss.Show();
        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdDirection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectDirection  '" + (comboBox2.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                IdDirection = string.Empty;
                while (thisReader.Read())
                {
                    IdDirection += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (IdDirection == "") IdDirection = "1";
            sql = "Select * From Direction JOIN Hotel ON (Direction.IdDirection = Hotel.IdDirection)"+
                "where Direction.IdDirection = " + IdDirection;
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
                this.comboBox3.DataSource = dt;
                this.comboBox3.DisplayMember = "Hotel";// столбец для отображения
                this.comboBox3.ValueMember = "HotelName";//столбец с id
                this.comboBox3.SelectedIndex = -1;
            }
           
            string date = dateTimePicker1.Value.Date.ToString();
            sql = "SELECT Transport.IdTransport as Id, Transport.Company as Компания,Transport.Cost as Стоимость ,Transport.DateOfDeparture as 'Дата отправления', Transport.TimeOfDeparture as 'Время отправления'," + 
            "Transport.DateOfArrival as 'Дата прибытия', Transport.TimeOfArrival as 'Время прибытия'"+
            "FROM Transport join direction on (Direction.IdDirection=Transport.IdTransport) where Transport.IdDirectionWhere  =" + IdDirection + " and Transport.DateOfDeparture > '" + date + "'";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Транспорт1");
                dataGridView1.DataSource = ds.Tables["Транспорт1"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }
 
    
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdHotel ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectHotel  '" + (comboBox3.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                IdHotel = string.Empty;
                while (thisReader.Read())
                {
                    IdHotel += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (IdHotel == "") IdHotel = "1";
            sql = "Select * From Hotel JOIN HotelRoom ON (Hotel.IdHotel = HotelRoom.IdHotelRoom)" +
                "where Hotel.IdHotel =" + IdHotel;
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
                this.comboBox4.DataSource = dt;
                this.comboBox4.DisplayMember = "HotelRoom";// столбец для отображения
                this.comboBox4.ValueMember = "RoomFull";//столбец с id
                this.comboBox4.SelectedIndex = -1;

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string IdDirection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectDirection  '" + (comboBox2.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                IdDirection = string.Empty;
                while (thisReader.Read())
                {
                    IdDirection += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (IdDirection == "") IdDirection = "1";
            string date = dateTimePicker1.Value.Date.ToString();
            sql = "SELECT Transport.IdTransport as Id, Transport.Company as Компания,Transport.Cost as Стоимость ,Transport.DateOfDeparture as 'Дата отправления', Transport.TimeOfDeparture as 'Время отправления'," +
            "Transport.DateOfArrival as 'Дата прибытия', Transport.TimeOfArrival as 'Время прибытия'" +
            "FROM Transport join direction on (Direction.IdDirection=Transport.IdTransport) where Transport.IdDirectionWhere  =" + IdDirection + " and Transport.DateOfDeparture >= '" + date + "'";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Транспорт1");
                dataGridView1.DataSource = ds.Tables["Транспорт1"].DefaultView;
                this.dataGridView1.Columns["Id"].Visible = false;
            }

           
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string IdHotel;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectHotel  '" + (comboBox3.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                IdHotel = string.Empty;
                while (thisReader.Read())
                {
                    IdHotel += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (IdHotel == "") IdHotel = "1";
            sql = "SELECT Transfers.IdTransfers as Id, Transfers.Class as Тип, Transfers.Cost as Стоимость, Transfers.Number as 'Номер трансфера', Transfers.TimeOfArrival as 'Время отбытия', Transfers.TimeOfDeparture as 'Время прибытия'"+
"From Transfers join Hotel ON (Transfers.IdHotel = Hotel.IdHotel) " + "WHERE Hotel.IdHotel = '" + IdHotel + "' and Transfers.Way = 'аэропорт-отель'";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Трансфер1");
                dataGridView4.DataSource = ds.Tables["Трансфер1"].DefaultView;
                this.dataGridView4.Columns["Id"].Visible = false;
            }
            
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sql = "SELECT Transfers.IdTransfers as Id, Transfers.Class as Тип, Transfers.Cost as Стоимость, Transfers.Number as 'Номер трансфера', Transfers.TimeOfArrival as 'Время отбытия', Transfers.TimeOfDeparture as 'Время прибытия'" +
"From Transfers join Hotel ON (Transfers.IdHotel = Hotel.IdHotel) " + "WHERE Hotel.HotelName = '" + comboBox3.Text + "' and Transfers.Way = 'отель-аэропорт'";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Трансфер2");
                dataGridView3.DataSource = ds.Tables["Трансфер2"].DefaultView;
                this.dataGridView3.Columns["Id"].Visible = false;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int days = Convert.ToInt32(textBox1.Text);
            end = Convert.ToDateTime(dateTimePicker1.Text);
            end = end.AddDays(days);
            textBox2.Text = end.ToString();
            sql = "SELECT Transport.IdTransport as Id,Transport.Company as Компания,Transport.Cost as Стоимость ,Transport.DateOfDeparture as 'Дата отправления', Transport.TimeOfDeparture as 'Время отправления'," +
"Transport.DateOfArrival as 'Дата прибытия', Transport.TimeOfArrival as 'Время прибытия'" +
"FROM Transport join direction on (Direction.IdDirection=Transport.IdTransport) where Transport.IdDirectionWhere = 5 and Transport.DateOfDeparture >= '" + textBox2.Text+"'";
            //this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Транспорт2");
                dataGridView2.DataSource = ds.Tables["Транспорт2"].DefaultView;
                this.dataGridView2.Columns["Id"].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string res, res2, res3, res4;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectTraveler  '" + (comboBox1.Text) + "'";
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectHotel  '" + (comboBox3.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                res3 = string.Empty;
                while (thisReader.Read())
                {
                    res3 += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string prov = comboBox4.Text;
                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectHotelRoom  '" + (comboBox4.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                res4 = string.Empty;
                while (thisReader.Read())
                {
                    res4 += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int rowindex1 = dataGridView2.CurrentCell.RowIndex;
            int rowindex2 = dataGridView4.CurrentCell.RowIndex;
            int rowindex3 = dataGridView3.CurrentCell.RowIndex;

            string select = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            string select2 = dataGridView2.Rows[rowindex1].Cells[0].Value.ToString();
            string select3 = dataGridView4.Rows[rowindex2].Cells[0].Value.ToString();
            string select4 = dataGridView3.Rows[rowindex3].Cells[0].Value.ToString();
            string date = dateTimePicker1.Value.Date.ToString();
            sql = "INSERT INTO Trip VALUES " +
                "(" + res + ", " + res2 + ", " + res3 + ", '" + date + "', '" + textBox2.Text + "', " + textBox3.Text + ", " + res4 + ", " + select + ", " + select2 + ", " + select3 + ", " + select4 + ", "+textBox1.Text+")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Данные добавлены!");
            }
            this.Close();
            PytevkaCreate ss = new PytevkaCreate();
            ss.Show();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            string id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " EXEC IdDetectDirection  '" + (comboBox2.Text) + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                id = string.Empty;
                while (thisReader.Read())
                {
                    id += thisReader["id"];
                }
                thisReader.Close();
                connection.Close();
            }
            if (id == "") id = "1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int rowindex1 = dataGridView2.CurrentCell.RowIndex;
                int rowindex2 = dataGridView4.CurrentCell.RowIndex;
                int rowindex3 = dataGridView3.CurrentCell.RowIndex;

                string select = dataGridView1.Rows[rowindex].Cells[0].Value.ToString(); 
                string select2 = dataGridView2.Rows[rowindex1].Cells[0].Value.ToString();
                string select3 = dataGridView4.Rows[rowindex2].Cells[0].Value.ToString();
                string select4 = dataGridView3.Rows[rowindex3].Cells[0].Value.ToString();

                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = " DECLARE  @Cost1 int, @CostT1 int, @CostT2 int, @CostT3 int, @CostT4 int, @Cost2 int" +
                    " EXEC CostOfTrip " + id + ", " + textBox1.Text + ", " + select + ", " + select2 + ", "+select3+", "+select4+", @Cost1 output, @CostT1 output, @CostT2 output, @CostT3 output, @CostT4 output, @Cost2 output;";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                string res = string.Empty;
                while (thisReader.Read())
                {
                    res += thisReader["Стоимость"];
                }
                thisReader.Close();
                connection.Close();
                textBox3.Text = res;
               
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
