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
using WareHouse_Manager.pages;
using MySql.Data.MySqlClient;


using Spire.Doc;
using System.Windows.Forms;
using System.Drawing.Printing;
using PrintDialog = System.Windows.Forms.PrintDialog;

namespace WareHouse_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnClickStockList(object sender, RoutedEventArgs e)
        {
            Main.Content = new StockList();
        }

        private void BtnClickBulkSheet(object sender, RoutedEventArgs e)
        {
            Main.Content = new BulkSheet();
            

        }
    }
}
