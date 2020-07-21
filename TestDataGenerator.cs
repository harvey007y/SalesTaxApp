﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

using System.Data;
using System.Data.SqlClient;

namespace SalesTaxApp
{
    public class TestDataGenerator : INotifyPropertyChanged
    {
        private TestDataGenerator()
        {
            productList = new ObservableCollection<Product>();
           
            NumberOfRecordsToGenerate = 1000;
        }

        static TestDataGenerator()
        {
            instance = null;
        }

        private ObservableCollection<Product> productList;

        private double testDataGenerationPercent;
        private bool isTestDataGenerationInProgress;
        private int numberOfRecordsToGenerate;

        private static TestDataGenerator instance;

        public static TestDataGenerator Instance
        {
            get
            {
                if (instance == null) instance = new TestDataGenerator();

                return instance;
            }
        }

        public int NumberOfRecordsToGenerate
        {
            get
            {
                return numberOfRecordsToGenerate;
            }
            set
            {
                numberOfRecordsToGenerate = value;
                NotifyPropertyChanged("NumberOfRecordsToGenerate");
            }
        }

        public ObservableCollection<Product> productList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                NotifyPropertyChanged("ProductList");
            }
        }



        public double TestDataGenerationPercent
        {
            get
            {
                return testDataGenerationPercent;
            }
            set
            {
                testDataGenerationPercent = value;
                NotifyPropertyChanged("TestDataGenerationPercent");
            }
        }

        public bool IsTestDataGenerationInProgress
        {
            get
            {
                return isTestDataGenerationInProgress;
            }
            set
            {
                isTestDataGenerationInProgress = value;
                NotifyPropertyChanged("IsTestDataGenerationInProgress");
            }
        }

        public void GenerateTestData(Action<EventArgs> callback)
        {
            if (NumberOfRecordsToGenerate > 0)
            {
                IsTestDataGenerationInProgress = true;

                List<Product> list = new List<Product>();
                productList = new ObservableCollection<Product>();
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    // ********************************************************************
                    // Code Generated by Ideal Tools Organizer at http://idealautomate.com
                    // ********************************************************************
                    // Define Query String
                    string queryString =
                    "SELECT [Id] " +
                    ",[Description] " +
                    ",[Price] " +
                    ",[Quantity] " +
                    ",[IsBook] " +
                    ",[IsFood] " +
                    ",[IsMedical] " +
                    ",[IsImported] " +
                    ",[BasePrice] " +
                    ",[Tax] " +
                    ",[TotalPrice] " +
                    ",[LastCalculatedTax] " +
                    ",[LastCalculatedTotalPrice] " +
                    "FROM [dbo].[SalesTaxProducts] " +
                   "";
                    // Define Connection String
                    string strConnectionString = null;
                    strConnectionString = @"Data Source=.\SQLEXPRESS02;Initial Catalog=IdealAutomateDB;Integrated Security=SSPI";
                    // Define .net fields to hold each column selected in query
                    Int32 int_SalesTaxProducts_Id;
                    String str_SalesTaxProducts_Description;
                    Decimal dec_SalesTaxProducts_Price;
                    Int32 int_SalesTaxProducts_Quantity;
                    Boolean bool_SalesTaxProducts_IsBook;
                    Boolean bool_SalesTaxProducts_IsFood;
                    Boolean bool_SalesTaxProducts_IsMedical;
                    Boolean bool_SalesTaxProducts_IsImported;
                    Decimal dec_SalesTaxProducts_BasePrice;
                    Decimal dec_SalesTaxProducts_Tax;
                    Decimal dec_SalesTaxProducts_TotalPrice;
                    Decimal dec_SalesTaxProducts_LastCalculatedTax;
                    Decimal dec_SalesTaxProducts_LastCalculatedTotalPrice;
                    // Define a datatable that we will define columns in to match the columns
                    // selected in the query. We will use sqldatareader to read the results
                    // from the sql query one row at a time. Then we will add each of those
                    // rows to the datatable - this is where you can modify the information
                    // returned from the sql query one row at a time. Finally, we will
                    // bind the table to the gridview.
                    DataTable dt = new DataTable();

                    using (SqlConnection connection = new SqlConnection(strConnectionString))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        // Define a column in the table for each column that was selected in the sql query 
                        // We do this before the sqldatareader loop because the columns only need to be  
                        // defined once. 

                        DataColumn column = null;
                        column = new DataColumn("SalesTaxProducts_Id", Type.GetType("System.Int32"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_Description", Type.GetType("System.String"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_Price", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_Quantity", Type.GetType("System.Int32"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_IsBook", Type.GetType("System.Boolean"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_IsFood", Type.GetType("System.Boolean"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_IsMedical", Type.GetType("System.Boolean"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_IsImported", Type.GetType("System.Boolean"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_BasePrice", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_Tax", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_TotalPrice", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_LastCalculatedTax", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        column = new DataColumn("SalesTaxProducts_LastCalculatedTotalPrice", Type.GetType("System.Decimal"));
                        dt.Columns.Add(column);
                        // Read the results from the sql query one row at a time 
                        while (reader.Read())
                        {
                            // define a new datatable row to hold the row read from the sql query 
                            DataRow dataRow = dt.NewRow();
                            // Move each field from the reader to a holding field in .net 
                            // ******************************************************************** 
                            // The holding field in .net is where you can alter the contents of the 
                            // field 
                            // ******************************************************************** 
                            // Then, you move the contents of the holding .net field to the column in 
                            // the datarow that you defined above 
                            if (!(reader.IsDBNull(0)))
                            {
                                int_SalesTaxProducts_Id = reader.GetInt32(0);
                                dataRow["SalesTaxProducts_Id"] = int_SalesTaxProducts_Id;
                            }
                            if (!(reader.IsDBNull(1)))
                            {
                                str_SalesTaxProducts_Description = reader.GetString(1);
                                dataRow["SalesTaxProducts_Description"] = str_SalesTaxProducts_Description;
                            }
                            if (!(reader.IsDBNull(2)))
                            {
                                dec_SalesTaxProducts_Price = reader.GetDecimal(2);
                                dataRow["SalesTaxProducts_Price"] = dec_SalesTaxProducts_Price;
                            }
                            if (!(reader.IsDBNull(3)))
                            {
                                int_SalesTaxProducts_Quantity = reader.GetInt32(3);
                                dataRow["SalesTaxProducts_Quantity"] = int_SalesTaxProducts_Quantity;
                            }
                            if (!(reader.IsDBNull(4)))
                            {
                                bool_SalesTaxProducts_IsBook = reader.GetBoolean(4);
                                dataRow["SalesTaxProducts_IsBook"] = bool_SalesTaxProducts_IsBook;
                            }
                            if (!(reader.IsDBNull(5)))
                            {
                                bool_SalesTaxProducts_IsFood = reader.GetBoolean(5);
                                dataRow["SalesTaxProducts_IsFood"] = bool_SalesTaxProducts_IsFood;
                            }
                            if (!(reader.IsDBNull(6)))
                            {
                                bool_SalesTaxProducts_IsMedical = reader.GetBoolean(6);
                                dataRow["SalesTaxProducts_IsMedical"] = bool_SalesTaxProducts_IsMedical;
                            }
                            if (!(reader.IsDBNull(7)))
                            {
                                bool_SalesTaxProducts_IsImported = reader.GetBoolean(7);
                                dataRow["SalesTaxProducts_IsImported"] = bool_SalesTaxProducts_IsImported;
                            }
                            if (!(reader.IsDBNull(8)))
                            {
                                dec_SalesTaxProducts_BasePrice = reader.GetDecimal(8);
                                dataRow["SalesTaxProducts_BasePrice"] = dec_SalesTaxProducts_BasePrice;
                            }
                            if (!(reader.IsDBNull(9)))
                            {
                                dec_SalesTaxProducts_Tax = reader.GetDecimal(9);
                                dataRow["SalesTaxProducts_Tax"] = dec_SalesTaxProducts_Tax;
                            }
                            if (!(reader.IsDBNull(10)))
                            {
                                dec_SalesTaxProducts_TotalPrice = reader.GetDecimal(10);
                                dataRow["SalesTaxProducts_TotalPrice"] = dec_SalesTaxProducts_TotalPrice;
                            }
                            if (!(reader.IsDBNull(11)))
                            {
                                dec_SalesTaxProducts_LastCalculatedTax = reader.GetDecimal(11);
                                dataRow["SalesTaxProducts_LastCalculatedTax"] = dec_SalesTaxProducts_LastCalculatedTax;
                            }
                            if (!(reader.IsDBNull(12)))
                            {
                                dec_SalesTaxProducts_LastCalculatedTotalPrice = reader.GetDecimal(12);
                                dataRow["SalesTaxProducts_LastCalculatedTotalPrice"] = dec_SalesTaxProducts_LastCalculatedTotalPrice;
                            }
                            // Add the row to the datatable 
                            dt.Rows.Add(dataRow);
                        }

                        // Call Close when done reading. 
                        reader.Close();
                    }

                    int ctr = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        Product dataItem = new Product();
                        dataItem.Id = Int32.Parse(item["SalesTaxProducts_Id"].ToString());
                        dataItem.Description = item["SalesTaxProducts_Description"].ToString();
                        Decimal money = 0.00M;
                        if (item["SalesTaxProducts_Price"] != null)
                        {
                            Decimal.TryParse(item["SalesTaxProducts_Price"].ToString(), out money);
                        }
                        dataItem.Price = money;

                        int amt = 0;
                        if (item["SalesTaxProducts_Quantity"] != null)
                        {
                            Int32.TryParse(item["SalesTaxProducts_Quantity"].ToString(), out amt);
                        }
                        dataItem.Quantity = amt;

                        if ((bool)item["SalesTaxProducts_IsBook"])
                        {
                            dataItem.IsBook = true;
                        }
                        else
                        {
                            dataItem.IsBook = false;
                        }

                        if ((bool)item["SalesTaxProducts_IsFood"])
                        {
                            dataItem.IsFood = true;
                        }
                        else
                        {
                            dataItem.IsFood = false;
                        }

                        if ((bool)item["SalesTaxProducts_IsMedical"])
                        {
                            dataItem.IsMedical = true;
                        }
                        else
                        {
                            dataItem.IsMedical = false;
                        }

                        if ((bool)item["SalesTaxProducts_IsImported"])
                        {
                            dataItem.IsImported = true;
                        }
                        else
                        {
                            dataItem.IsImported = false;
                        }




                        list.Add(dataItem);
                    }


                };

                worker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {


                    productList = new ObservableCollection<Product>(list);



                    //IsTestDataGenerationInProgress = false;

                    //if (callback != null) callback(EventArgs.Empty);
                };

                worker.RunWorkerAsync();

            }
        }

    
        #region Internal - random data generation
        
        Random random;
        private void initRandomGenerator()
        {
            random = new Random((int)DateTime.Now.Ticks);

            random = new Random((int)new DateTime(
                random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year), 
                random.Next(1,12), 
                random.Next(1,28)).Ticks);

            System.Threading.Thread.Sleep(5);
        }

        private void fillWithTheRandomData(Employee e, int i)
        {
            e.Id               = i;

            e.Name             = getRandomName();
            e.Email            = getRandomEmail(e.Name);
            e.Address          = getRandomAddress();
            e.EmployeeGuid     = getEmployeeGuid(i);
            e.WorkExperience = random.Next(0, 40);
            e.Position         = i % 13 == 0 ? null : getRadndomPosition();
            e.EmployeeStatusId = getRandomStatusId();
            e.IsInterviewed    = getRandomIsInterviewed();
            e.DateOfBirth      = getRandomDateOfBirth();
        }

        private string getRandomName()
        {
            int number = random.Next(NAMES.Length - 1);

            return NAMES[number];
        }

        private string getRandomEmail(string email)
        {
            return email + "-" + getRandomString(3) + "@" + getRandomDomain();
        }

        private string getRandomAddress()
        {
            return getRandomString(random.Next(5, 10)) + ", " + getRandomString(random.Next(5, 15)) + " " + random.Next(0, 200);
        }

        private Guid? getEmployeeGuid(int i)
        {
            Guid? value;

            if (i % 10 == 0)
            {
                value = null;
            }
            else
            {
                value = Guid.NewGuid();
            }

            return value;
        }

        private EmployeePosition getRadndomPosition()
        {
            int number = random.Next(POSITIONS.Length - 1);

            return POSITIONS[number];
        }

        private int getRandomStatusId()
        {
            return random.Next(1, STATUS.Length);
        }

        private bool getRandomIsInterviewed()
        {
            return random.NextDouble() < 0.5 ? false : true;
        }

        private DateTime getRandomDateOfBirth()
        {
            return new DateTime(
                random.Next(1950, 1990), random.Next(1, 12), random.Next(1, 28));
        }

        private readonly string[] NAMES = new string[]
        {
            "Mark", "Tom", "Harry", "Sally", "Sandra", "Paul", "Anastasia", "David", "Alex", "Michael", "Tina", "Zachary", "Bob", "Elise",
            "Jime", "Anderry","Rustin","Ivadon","Nichardo","Jasey","Rent","Millack","Alenn","Serrett","Tanifer","Syllica","Allickie","Jacey"
            ,"Janther","Racey","Alicherry","Clary","Kather","Bonna"
        };

        private readonly string[] DOMAINS = new string[]
        {
            "xxx.com", "aa.com", "min.com", "erp.com", "holidays.com", "mon.com", "san.com", "sun.com", "ibm.com", "hp.com", "google.com", "yahoo.com", "bing.com", "ask.com"
        };

        private readonly string ASCII = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private readonly EmployeeStatus[] STATUS = new EmployeeStatus[]
        {
            new EmployeeStatus{Id="", Name= ""},
             new EmployeeStatus{Id="null", Name= "null"},
            new EmployeeStatus{Id="Applied", Name="Applied"},
            new EmployeeStatus{Id="Not Applied", Name="Not Applied"},
            new EmployeeStatus{Id="Not Interested", Name="Not Interested"},
            new EmployeeStatus{Id="Not Qualified", Name="Not Qualified"},
            new EmployeeStatus{Id="Not Remote", Name="Not Remote"},
            new EmployeeStatus{Id="Closed", Name="Closed"},
            new EmployeeStatus{Id="Duplicate", Name="Duplicate"},
            new EmployeeStatus{Id="Too much travel", Name="Too much travel"},
            new EmployeeStatus{Id="Requires Relocation", Name="Requires Relocation"},
            new EmployeeStatus{Id="Wrong location", Name="Wrong location"},
            new EmployeeStatus{Id="Broken Link", Name="Broken Link"}


        };

        private readonly EmployeePosition[] POSITIONS = new EmployeePosition[] 
        { 
            new EmployeePosition {Id=1,  Name="EAP Specialist"},
            new EmployeePosition {Id=2,  Name="Instructor"},
            new EmployeePosition {Id=3,  Name="Full professor"},
            new EmployeePosition {Id=4,  Name="ERP Specialist"},
            new EmployeePosition {Id=5,  Name="SQL Programmer"},
            new EmployeePosition {Id=6,  Name="QA Tester"},
            new EmployeePosition {Id=7,  Name="Senior Software Engineer "},
            new EmployeePosition {Id=8,  Name="Technical Analyst"},
            new EmployeePosition {Id=9,  Name="Web Master"},
            new EmployeePosition {Id=10, Name="Programmer Analyst "}
        };

        private string getRandomDomain()
        {
            int number = random.Next(DOMAINS.Length - 1);

            return NAMES[number];
        }

        private char getRandomChar()
        {
            int number = random.Next(ASCII.Length - 1);

            return ASCII[number];
        }

        private string getRandomString(int length)
        {
            StringBuilder randomString = new StringBuilder();

            for(int i = 0; i < length; i++)
            {
                randomString.Append(getRandomChar());
            }

            return randomString.ToString();
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
