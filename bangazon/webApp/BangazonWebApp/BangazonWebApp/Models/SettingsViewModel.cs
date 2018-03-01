using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class SettingsViewModel
    {
        [Display(Name = "Payment Types")]
        public ICollection<PaymentType> PaymentTypes { get; set; }

        public string StatusMessage { get; set; }
    }
}
