using System.Collections.Generic;
using System.Linq;

namespace cli
{
    public class ProductManager
    {
        private List<Product> _productTable = new List<Product>();

        public void Add(Product product)
        {
            _productTable.Add(product);
        }

        public Product GetSingleProduct(int id)
        {
            return _productTable.Where(p => p.ProductId == id).Single();
        }

        public List<Product> GetAllProducts()
        {
            return _productTable;
        }
    }
}