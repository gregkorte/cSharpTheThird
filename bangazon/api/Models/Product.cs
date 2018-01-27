using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(55)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}