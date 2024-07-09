using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class ProductDetail : EntityBase
    {
        public ProductDetail()
        {
            
        }

        public ProductDetail(string productDetailTitle, string productDetailDescription, int categoryId)
        {
            ProductDetailTitle = productDetailTitle;
            ProductDetailDescription = productDetailDescription;
            CategoryId = categoryId;
        }

        public string ProductDetailTitle { get; set; }
        public string ProductDetailDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}


