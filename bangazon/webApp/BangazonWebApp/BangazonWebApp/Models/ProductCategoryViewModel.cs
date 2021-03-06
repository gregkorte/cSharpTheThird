﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWebApp.Models
{
    public class ProductCategoryViewModel
    {
        public int ProductTypeId { get; set; }

        public string Label { get; set; }

        public int ProductCount { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
