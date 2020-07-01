using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace SalesTaxApp
{
    /// <summary>
    /// ProductManager class is for the business logic end and application work
    /// that is done for the GUI.  This class creates and
    /// holds an list of Product objects and each object holds its own data and
    /// applicable methods. 
    /// </summary>
    class ProductManager
    {
        // Main List to hold products for the application
        public ObservableCollection<Product> productList; 

        /// <summary>
        /// method ProductManager()
        /// Description: Constructor for the ProductManager class
        /// Instantiates the productList object with Product type objects
        /// Inputs: None
        /// Outputs: None
        /// </summary>
        public ProductManager()
        {
            productList = new ObservableCollection<Product>();   
        } // end of ProductManager()

        public decimal GetTaxTotal()
        {
            decimal totTaxSum = productList.Sum(x => x.LastCalculatedTax);
            return totTaxSum;
        }

        public decimal GetPriceTotal()
        {
            decimal totPriceSum = productList.Sum(x => x.LastCalculatedTotalPrice);
            return totPriceSum;
        }
    }
}
