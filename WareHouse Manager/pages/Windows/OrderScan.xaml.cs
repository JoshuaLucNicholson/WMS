using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WareHouse_Manager.pages.Windows
{
    /// <summary>
    /// Interaction logic for OrderScan.xaml
    /// </summary>
    /// //test
    public partial class OrderScan : Window
    {
        public OrderScan()
        {
            InitializeComponent();

            string connstring = "server=localhost; uid=root;pwd=password123;database=WareHouse";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            string sql = "select * from stockdata";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            OrderItemsDataTable.ItemsSource = table.DefaultView;
            con.Close();
        }
    }
}
