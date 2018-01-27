using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public ICollection<OrderProduct> OrderProducts;
    }
}