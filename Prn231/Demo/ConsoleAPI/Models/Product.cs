using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPI.Models
{
    internal class Product
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal? unitPrice { get; set; }
        public int? unitsInStock { get; set; }
        public string? image { get; set; }
        public int? categoryId { get; set; }
    }
}
