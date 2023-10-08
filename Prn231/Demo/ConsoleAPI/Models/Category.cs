using System;
using System.Collections.Generic;

namespace ConsoleAPI.Models
{
    public partial class Category
    {
        public Category()
        {
        }

        public int categoryId { get; set; }
        public string? categoryName { get; set; }

        public override string? ToString()
        {
            return categoryId + "\t" + categoryName ;
        }
    }
}
