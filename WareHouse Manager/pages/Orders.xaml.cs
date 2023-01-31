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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using WareHouse_Manager.pages.Windows;
using Google.Protobuf.WellKnownTypes;
using System.Xml.Linq;

namespace WareHouse_Manager.pages
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();

            string connstring = "server=localhost; uid=root;pwd=password123;database=WareHouse";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            string sql = "select orderID, customer, `lines` , status, date(date) as date from orders";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);


            string result = "0";
            foreach (DataRow row in table.Rows)
            { 
                string linecountSQL = "select count(itemid) from orderlines where orderid = " + row["orderID"].ToString();
                MySqlCommand lineCountcmd = new MySqlCommand(linecountSQL, con);
                result = Convert.ToString(lineCountcmd.ExecuteScalar());

                row["Lines"] = result;
                result = "0";
            }

            

            orders.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void uxDeclaration_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }


    }
}
