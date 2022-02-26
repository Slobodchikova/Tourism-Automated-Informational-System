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
    public partial class Password : Form
    {
        string login ;
        string password;
        string sql;
        //connection.Open();
        DataTable dt;
        string connectionString = @"Data Source=LAPTOP-C78N00EF;Initial Catalog= Travel;Integrated Security=True";

        public Password()
        {
            InitializeComponent();
            sql = "SELECT * FROM Access";
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

        private void Password_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "travelDataSet.Access". При необходимости она может быть перемещена или удалена.
            this.accessTableAdapter.Fill(this.travelDataSet.Access);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login = comboBox1.Text;
            password = textBox1.Text;
            sql = "SELECT IdAccess FROM Access where [Group] = '"+login+"' and Pass = '"+password+"'";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                dt = new DataTable();
                adapter.Fill(dt);
            }  
               if (dt.Rows.Count > 0)
               {
                   // Нужный Вам ID
                   string ID = dt.Rows[0][0].ToString();
                   if (ID == "1")
                   {
                       this.Hide();
                       admin ss = new admin();
                       ss.Show();
                   }
                   if (ID == "2")
                   {
                       this.Hide();
                       Client ss = new Client();
                       ss.Show();
                   }
                   if (ID == "3")
                   {
                       this.Hide();
                       Transport ss = new Transport();
                       ss.Show();
                   }
                   if (ID == "4")
                   {
                       this.Hide();
                       Hotel ss = new Hotel();
                       ss.Show();
                   }
               }
               else
               {
                   MessageBox.Show("Неправильно введённые имя или пароль");
               }

           }
        }

  
    }

