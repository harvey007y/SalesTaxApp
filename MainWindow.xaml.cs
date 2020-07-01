using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls;
namespace SalesTaxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductManager productManager = new ProductManager();
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = productManager.productList;
            lblSumTax.Content = "Sum of Tax = $0.00";
            lblSumTotalPrice.Content = "Sum of Total Price = $0.00";
        }

        private void dataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            updateGrandTotals();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                stackPanelPrintArea.Measure(pageSize);
                stackPanelPrintArea.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(stackPanelPrintArea, Title);
            }
        }



        private void updateGrandTotals()
        {
            decimal priceTotal = productManager.GetPriceTotal();
            decimal taxTotal = productManager.GetTaxTotal();
            lblSumTax.Content = "Sum of Tax = " + String.Format("{0:C2}", taxTotal);
            lblSumTotalPrice.Content = "Sum of Total Price = " + String.Format("{0:C2}", priceTotal);
        }

        private void dataGrid_UnloadingRow(object sender, Microsoft.Windows.Controls.DataGridRowEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem != null || ((DataGrid)sender).CurrentItem == null)
            {
                return;
            }
            updateGrandTotals();
        }
    }
}
