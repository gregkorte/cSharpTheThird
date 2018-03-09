using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonWebApp.Models
{
    public class MyProductsViewModel
    {
        public string Title { get; set; }

        public int QuantityAvailable { get; set; }

        public int QuantitySold { get; set; }
    }
}