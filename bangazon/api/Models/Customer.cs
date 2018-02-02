using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(55)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(55)]
        public string LastName { get; set; }
        
        public bool active { get; set; } = false;
        public DateTime LastLogin { get; set; }
    }
}