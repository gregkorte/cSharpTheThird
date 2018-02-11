using System;
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

        public void DeleteProduct(Product product)
        {
            _productTable.Remove(product);
        }

        public bool CheckProductForOrders(int id)
        {
            return _productTable.Where(p => p.ProductId == id).Any();
        }

        public List<Product> GetAllCustomerProducts(int id)
        {
            return _productTable.Where(p => p.CustomerId == id).ToList();
        }

        public void UpdateProduct(int id, string property, double value)
        {
            Product product = _productTable.Where(p => p.ProductId == id).Single();
            product.GetType().GetProperty(property).SetValue(product, value);
        }

        public List<Product> GetStaleProducts()
        {
            return _productTable.Where(p => p.DateCreated < DateTime.Now.AddDays(-180)).ToList();
        }
    }
}