using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using WareHouse_Manager.pages.Windows;


namespace WareHouse_Manager.pages
{
    /// <summary>
    /// Interaction logic for BulkSheet.xaml
    /// </summary>
    public partial class BulkSheet : Page
    {
        public BulkSheet()
        {
            InitializeComponent();
            bulkDataTable.ItemsSource = null;
            string connstring = "server=localhost; uid=root;pwd=password123;database=WareHouse";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open(); 
            string sql = "SELECT x.itemId, y.description, x.location , x.quantity FROM bulklocations x join stockdata y on x.itemId = y.ItemId;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            bulkDataTable.ItemsSource = table.DefaultView;
            con.Close();


        }

        private void uxDeclaration_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             DataRowView row = (DataRowView)bulkDataTable.SelectedItems[0];
             string stockId = row[0].ToString();
             string stockDesc = row[1].ToString();
             string stockqty = row[2].ToString();
             string stockLocation = row[3].ToString();
             bulkListEditRow secondWin = new bulkListEditRow(stockId, stockDesc, stockqty, stockLocation); 
             secondWin.ShowDialog();

        }
    }
}
