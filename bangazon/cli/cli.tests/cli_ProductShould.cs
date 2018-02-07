using System;
using Xunit;

namespace cli.tests
{
    public class cli_ProductShould
    {
        [Fact]
        public void Add(Product product)
        {
            Product _product = new Product(
                1,
                "Shovel",
                "I dig this thing",
                34.99,
                1,
                1
            );
        }
    }
}