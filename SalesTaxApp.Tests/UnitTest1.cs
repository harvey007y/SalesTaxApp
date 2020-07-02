using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxApp;

namespace SalesTaxApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            // Arrange
            ProductManager productManager = new ProductManager();
            Product product = new Product()
            {
                Description = "Book",
                Price = 12.49M,
                Quantity = 2,
                IsBook = true
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Music CD",
                Price = 14.99M,
                Quantity = 1
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Chocolate bar",
                Price = 0.85M,
                Quantity = 1,
                IsFood = true
            };
            productManager.productList.Add(product);

            // Assert
            product = productManager.productList[0];
            Assert.AreEqual(0.00M, product.Tax);
            Assert.AreEqual(24.98M, product.TotalPrice);

            product = productManager.productList[1];
            Assert.AreEqual(1.50M, product.Tax);
            Assert.AreEqual(16.49M, product.TotalPrice);

            product = productManager.productList[2];
            Assert.AreEqual(0.00M, product.Tax);
            Assert.AreEqual(0.85M, product.TotalPrice);

            decimal taxTotal = productManager.GetTaxTotal();
            Assert.AreEqual(taxTotal, 1.50M);

            decimal priceTotal = productManager.GetPriceTotal();
            Assert.AreEqual(priceTotal, 42.32M);


        }

        [TestMethod]
        public void TestCase2()
        {
            // Arrange
            ProductManager productManager = new ProductManager();
            Product product = new Product()
            {
                Description = "Imported Chocolates",
                Price = 10.00M,
                Quantity = 1,
                IsFood = true,
                IsImported = true
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Imported Perfume",
                Price = 47.50M,
                Quantity = 1,
                IsImported = true
            };
            productManager.productList.Add(product);



            // Assert
            product = productManager.productList[0];
            Assert.AreEqual(0.50M, product.Tax);
            Assert.AreEqual(10.50M, product.TotalPrice);

            product = productManager.productList[1];
            Assert.AreEqual(7.15M, product.Tax);
            Assert.AreEqual(54.65M, product.TotalPrice);

            decimal taxTotal = productManager.GetTaxTotal();
            Assert.AreEqual(taxTotal, 7.65M);

            decimal priceTotal = productManager.GetPriceTotal();
            Assert.AreEqual(priceTotal, 65.15M);


        }

        [TestMethod]
        public void TestCase3()
        {
            // Arrange
            ProductManager productManager = new ProductManager();
            Product product = new Product()
            {
                Description = "Imported Perfume",
                Price = 27.99M,
                Quantity = 1,
                IsImported = true
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Perfume",
                Price = 18.99M,
                Quantity = 1
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Headache pills",
                Price = 9.75M,
                Quantity = 1,
                IsMedical = true
            };
            productManager.productList.Add(product);

            product = new Product()
            {
                Description = "Imported Chocolates",
                Price = 11.25M,
                Quantity = 2,
                IsFood = true,
                IsImported = true
            };
            productManager.productList.Add(product);

            // Assert
            product = productManager.productList[0];
            Assert.AreEqual(4.20M, product.Tax);
            Assert.AreEqual(32.19M, product.TotalPrice);

            product = productManager.productList[1];
            Assert.AreEqual(1.90M, product.Tax);
            Assert.AreEqual(20.89M, product.TotalPrice);

            product = productManager.productList[2];
            Assert.AreEqual(0.00M, product.Tax);
            Assert.AreEqual(9.75M, product.TotalPrice);

            product = productManager.productList[3];
            Assert.AreEqual(1.20M, product.Tax);
            Assert.AreEqual(23.70M, product.TotalPrice);

            decimal taxTotal = productManager.GetTaxTotal();
            Assert.AreEqual(taxTotal, 7.30M);

            decimal priceTotal = productManager.GetPriceTotal();
            Assert.AreEqual(priceTotal, 86.53M);


        }
    }
}
