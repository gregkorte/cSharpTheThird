using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonWebApp.Models
{
    public class Order
    {
        [Key]
        [Display(Name="Order #")]
        public int OrderId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public int? PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date")]
        public DateTime DateCreated { get; set; }

        [Display(Name="Line Items")]
        public ICollection<OrderProduct> LineItmes { get; set; }
    }
}