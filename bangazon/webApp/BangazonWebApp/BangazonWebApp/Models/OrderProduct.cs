﻿using System.ComponentModel.DataAnnotations;

namespace BangazonWebApp.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}