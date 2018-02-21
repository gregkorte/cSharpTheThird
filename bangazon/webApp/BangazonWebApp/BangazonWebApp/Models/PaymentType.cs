using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date")]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(55)]
        [Display(Name="Account Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name="Account Number")]
        public string AccountNumber { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }
}
