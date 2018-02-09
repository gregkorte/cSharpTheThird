using System;
using System.Collections.Generic;
using Xunit;

namespace cli.tests
{
    public class ProductShould
    {
        private Product _product;
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
        public void CheckExistingProductForOrderStatus()
        {
            manager.Add(_product);
            bool exists = manager.CheckProductForOrders(1);

            Assert.True(exists);
        }
    }
}