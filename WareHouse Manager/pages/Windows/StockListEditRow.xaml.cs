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
using MySql.Data.MySqlClient;

namespace WareHouse_Manager.pages.Windows
{
    /// <summary>
    /// Interaction logic for StockListEditRow.xaml
    /// </summary>
    public partial class StockListEditRow : Window
    {

        public StockListEditRow(string ID, string description, string qty, string location)
        {

            InitializeComponent();
            Stock_Id_Value.Text = ID;
            Description_Value.Text = description;
            Location_Value.Text= location;
            Qty_Value.Text = qty.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateStock_Click(object sender, RoutedEventArgs e)
        {
            string Stock_ID = Stock_Id_Value.Text;
            string description = description_box.Text;
            string location = location_box.Text;
            string qty = qty_box.Text;
            string dataToEdit = "";
            if (!string.IsNullOrEmpty(description))
            {
                dataToEdit = "`description`" + "= '" + description + "'";
            }

            if (!string.IsNullOrEmpty(location))
            {
                if (dataToEdit == "")
                {
                    dataToEdit =  "`location`" + "= " + "'" + location + "'";
                }
                else
                {
                    dataToEdit = dataToEdit + ","+ "`location`" + "= " + "'" + location + "'";
                }
   
            }

            if (!string.IsNullOrEmpty(qty))
            {
                if (dataToEdit == "")
                {
                    dataToEdit = "`qty` " + "= " + qty;
                }
                else
                {
                    dataToEdit = dataToEdit + ", " + "`qty`" + "= " + qty;
                }
            }

            string query = "UPDATE `warehouse`.`stockdata` SET " + dataToEdit + " WHERE (`ItemId` = '" + Stock_ID + "');";

            System.Windows.Forms.MessageBox.Show(query);
            string connstring = "server=localhost; uid=root;pwd=password123;database=WareHouse";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteReader();
            con.Close();

        }

    }
}
