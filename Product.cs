using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Media3D;

namespace SalesTaxApp
{
    /// <summary>
    /// The Product class creates product objects
    /// The ProductManager class creates a list of
    /// Product objects and provides the business logic updating total tax and 
    /// total price
    /// </summary>
    class Product : INotifyPropertyChanged
    {
        // Class Instance Variables for Object Data
        private string description; 
        private decimal price;      
        private int quantity;
        private bool isBook;     
        private bool isFood;     
        private bool isMedical;     
        private bool isImported;     
        private decimal basePrice;
        private decimal tax;
        private decimal totalPrice;
        private decimal lastCalculatedTax;      // allows you not to have to recalculate tax
                                                // when getting tax total for list
        private decimal lastCalculatedTotalPrice;       // allows you not to have to recalculate 
                                                        // when getting price total for list




        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Property to Get/Set the Description
        public string Description
        {
            get
            {
                return description;
            }
            set
            {

                if (value == null || value == string.Empty)
                    throw new Exception("Description cannot be null or empty");
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        } // end of Description

        // Property to Get/Set the Price
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < (decimal).01)
                    throw new Exception("Price cannot be less than .01");
                if (value >= 0)
                {
                    price = value;
                    basePrice = price * quantity;
                    NotifyPropertyChanged("BasePrice");
                    NotifyPropertyChanged("Tax");
                    NotifyPropertyChanged("TotalPrice");
                }
            }
        } // end of Price


        // Property to Get/Set the Quantity
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Quantity cannot be less than 1");
                if (value >= 0)
                {
                    quantity = value;
                    basePrice = price * quantity;
                    NotifyPropertyChanged("BasePrice");
                    NotifyPropertyChanged("Tax");
                    NotifyPropertyChanged("TotalPrice");
                }

            }
        } // end of Quantity

        // Property to Get/Set the IsBook
        public bool IsBook
        {
            get
            {
                return isBook;
            }
            set
            {

                isBook = value;
                NotifyPropertyChanged("Tax");
                NotifyPropertyChanged("TotalPrice");
            }
        } // end of IsBook

        public bool IsFood
        {
            get
            {
                return isFood;
            }
            set
            {
                isFood = value;
                NotifyPropertyChanged("Tax");
                NotifyPropertyChanged("TotalPrice");
            }
        } // end of IsFood

        public bool IsMedical
        {
            get
            {
                return isMedical;
            }
            set
            {
                isMedical = value;
                NotifyPropertyChanged("Tax");
                NotifyPropertyChanged("TotalPrice");
            }
        } // end of IsMedical

        // Property to Get/Set the IsImported
        public bool IsImported
        {
            get
            {
                return isImported;
            }
            set
            {

                isImported = value;

                NotifyPropertyChanged("Tax");
                NotifyPropertyChanged("TotalPrice");
            }
        } // end of IsImported

        // Property to Get/Set the BasePrice
        public decimal BasePrice
        {
            get
            {
                basePrice = price * quantity;
                return basePrice;
            }

        } // end of BasePrice

        // Property to Get/Set the Tax
        public decimal Tax
        {
            get
            {
                decimal taxrate = 0;
                if (!isBook && !isFood && !isMedical)
                {
                    taxrate = (decimal).10;
                }
                if (isImported)
                {
                    taxrate += (decimal).05;
                }
                decimal sumtax = 0;
                for (int i = 0; i < quantity; i++)
                {
                    tax = price * taxrate;
                    tax = RoundToNextDime(tax);
                    sumtax += tax;
                }

                tax = sumtax;
                LastCalculatedTax = sumtax;
                return sumtax;
            }

        } // end of Tax

        decimal RoundToNextDime(decimal d)
        {
            return Math.Ceiling(d * 20) / 20;
        }

        // Property to Get/Set the TotalPrice
        public decimal TotalPrice
        {
            get
            {
                totalPrice = basePrice + tax;
                LastCalculatedTotalPrice = totalPrice;
                return totalPrice;
            }

        } // end of TotalPrice

        // Property to Get/Set the LastCalculatedTax
        public decimal LastCalculatedTax
        {
            get
            {
                return lastCalculatedTax;
            }
            set
            {
                if (value >= 0)
                {
                    lastCalculatedTax = value;
                }
            }
        } // end of LastCalculatedTax

        // Property to Get/Set the LastCalculatedTotalPrice
        public decimal LastCalculatedTotalPrice
        {
            get
            {
                return lastCalculatedTotalPrice;
            }
            set
            {
                if (value >= 0)
                {
                    lastCalculatedTotalPrice = value;
                }
            }
        } // end of LastCalculatedTotalPrice
        


    }
}
