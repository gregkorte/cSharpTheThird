using System;
using Xunit;

namespace cli.tests
{
    public class cli_ProductShould
    {
        [Fact]
        public void Add()
        {
            Product _product = new Product(
                1,
                "Shovel",
                "I dig this thing",
                34.99,
                1,
                1
            );

            Assert.Equal(_product.ProductId, 1);
            Assert.Equal(_product.Name, "Shovel");
            Assert.Equal(_product.Description, "I dig this thing");
            Assert.Equal(_product.Price, 34.99);
            Assert.Equal(_product.ProductTypeId, 1);
            Assert.Equal(_product.CustomerId, 1);
        }
    }
}