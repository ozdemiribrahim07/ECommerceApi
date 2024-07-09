using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
            
        }

        public Brand(string brandName)
        {
            BrandName = brandName;
        }

        public string BrandName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
