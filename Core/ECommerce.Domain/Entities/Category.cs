using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

