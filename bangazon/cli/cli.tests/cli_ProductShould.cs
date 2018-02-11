using System;
using System.Collections.Generic;
using Xunit;

namespace cli.tests
{
    public class ProductShould
    {
        private Product _product;
        private Order _order;
        private OrderProduct _op1;
        private ProductManager manager = new ProductManager();

        public ProductShould()
        {
            _product = new Product(
                1,
                "Shovel",
                "I dig this thing",
                34.99,
                1,
                1
            );

            _order = new Order(
                1,
                1,
                null
            );

            _op1 = new OrderProduct();
            _op1.OrderProductId = 1;
            _op1.OrderId = 1;
            _op1.ProductId = 1;

        }

        [Fact]
        public void AddPropertiesToInstance()
        {
            Assert.Equal(_product.ProductId, 1);
            Assert.Equal(_product.Name, "Shovel");
            Assert.Equal(_product.Description, "I dig this thing");
            Assert.Equal(_product.Price, 34.99);
            Assert.Equal(_product.ProductTypeId, 1);
            Assert.Equal(_product.CustomerId, 1);
        }

        [Fact]
        public void GetSingleProduct()
        {
            manager.Add(_product);
            Product product = manager.GetSingleProduct(1);

            Assert.Equal(product.CustomerId, 1);
        }

        [Fact]
        public void GetAllProducts()
        {
            manager.Add(_product);
            List<Product> allProducts = manager.GetAllProducts();

            Assert.Contains(_product, allProducts);
        }

        [Fact]
        public void DeleteProduct()
        {
            manager.Add(_product);
            manager.DeleteProduct(_product);
            List<Product> allProducts = manager.GetAllProducts();

            Assert.Empty(allProducts);
        }

        [Fact]
        public void CheckProductForOrders()
        {
            manager.Add(_product);
            bool exists = manager.CheckProductForOrders(1);

            Assert.True(exists);
        }

        [Fact]
        public void GetAllCustomerProducts()
        {
            manager.Add(_product);
            List<Product> allCustomerProducts = manager.GetAllCustomerProducts(1);

            Assert.Contains(_product, allCustomerProducts);
        }

        [Fact]
        public void UpdateProduct()
        {
            manager.Add(_product);
            manager.UpdateProduct(1, "Price", 33.99);
            Product product = manager.GetSingleProduct(1);
             
            Assert.Equal(33.99, product.Price);  
        }

        [Fact]
        public void HavePropertyDateCreated()
        {
            manager.Add(_product);
            Product product = manager.GetSingleProduct(1);

            Assert.Equal(_product.DateCreated, product.DateCreated);
        }

        [Fact]
        public void GetStaleProductsNoOrdersMoreThan180()
        {
            manager.Add(_product);
            _product.DateCreated = new DateTime(2010, 09, 3, 9, 6, 13);
            manager.Add(_product);
            List<Product> staleProducts = manager.GetStaleProducts();

            Assert.Contains(_product, staleProducts);
        }
    }
}