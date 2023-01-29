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

using System.Printing;
using System.Reflection.Metadata;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using Window = System.Windows.Window;

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
        }

        private void UpdateBulk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;

            Document wordDoc = wordApp.Documents.Open(@"C:\Users\Joshu\Desktop\WareHouseManagmentSoftware");
            Bookmark bkm = wordDoc.Bookmarks["StockID"];
            Microsoft.Office.Interop.Word.Range rng = bkm.Range;
            rng.Text = "Adams Laura"; //Get value from any where 
        }

/*        public void Print()
        {
            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            // Create a FlowDocument dynamically.  
            FlowDocument doc = CreateFlowDocument();
            doc.Name = "FlowDoc";
            // Create IDocumentPaginatorSource from FlowDocument  
            IDocumentPaginatorSource idpSource = doc;
            // Call PrintDocument method to send document to printer  
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }

        private FlowDocument CreateFlowDocument()
        {
            // Create a FlowDocument  
            FlowDocument doc = new FlowDocument();
            // Create a Section  
            Section sec = new Section();
            // Create first Paragraph  
            Paragraph p1 = new Paragraph();
            // Create and add a new Bold, Italic and Underline  
            Bold bld = new Bold();
            bld.Inlines.Add(new Run("First Paragraph"));
            Italic italicBld = new Italic();
            italicBld.Inlines.Add(bld);
            Underline underlineItalicBld = new Underline();
            underlineItalicBld.Inlines.Add(italicBld);
            // Add Bold, Italic, Underline to Paragraph  
            p1.Inlines.Add(underlineItalicBld);
            // Add Paragraph to Section  
            sec.Blocks.Add(p1);
            // Add Section to FlowDocument  
            doc.Blocks.Add(sec);
            return doc;
        }*/
        private void cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
