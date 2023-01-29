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



using Spire.Doc;
using System.Windows.Forms;
using System.Drawing.Printing;
using PrintDialog = System.Windows.Forms.PrintDialog;

namespace WareHouse_Manager.pages.Windows
{
    /// <summary>
    /// Interaction logic for bulkListEditRow.xaml
    /// </summary>
    public partial class bulkListEditRow : Window
    {
       
        public bulkListEditRow(string ID, string description, string qty, string location)
        {
            InitializeComponent();
            Stock_Id_Value.Text = ID;
            Description_Value.Text = description;
            Location_Value.Text = location;
            Qty_Value.Text = qty.ToString();
        }

        private void UpdateBulk_Click(object sender, RoutedEventArgs e)
        {

        }


        private void print_Click(object sender, RoutedEventArgs e)
        {
            // Test File Location
            string filePath = "C:\\Users\\Joshu\\Documents\\ExampleDocument.docx";
            // Create a new document and load the input file
            Document doc = new Document();
            doc.LoadFromFile(filePath);

            // Replace all occurrences of the original word with the new word
            doc.Replace("StockId", Stock_Id_Value.Text, true, true);
            doc.Replace("Description", Description_Value.Text, true, true);
            doc.Replace("Qty", Location_Value.Text, true, true);
            doc.Replace("Location", Qty_Value.Text, true, true);

            PrintDocument printDoc = doc.PrintDocument;
            //Background printing  
            printDoc.Print();
            //Close window after printing
            Close();
        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
