using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonWebApp.Models
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

        [NotMapped]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please choose a category.")]
        public int ProductTypeId { get; set; }

        [Display(Name ="Category")]
        public ProductType ProductType { get; set; }

        [StringLength(30)]
        public string Location { get; set; }

        public string ImagePath { get; set; }

        [Display(Name="Line Items")]
        public virtual ICollection<OrderProduct> LineItems { get; set; }

    }
}