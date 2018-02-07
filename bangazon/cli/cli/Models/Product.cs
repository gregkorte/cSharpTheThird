using System;

namespace cli
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public int ProductTypeId { get; set; }
        public int CustomerId { get; set; }

        public Product(int id, string name, string description, double price, int ptId, int cId)
        {
            ProductId = id;
            Name = name;
            Description = description;
            Price = price;
            ProductTypeId = ptId;
            CustomerId = cId;
        }
    }
}