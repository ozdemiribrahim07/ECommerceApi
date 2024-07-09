using Bogus;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> b)
        {
            Faker faker = new Faker("tr");

            b.HasData(
            new Category
            {
               Id = 1,
               CategoryName = "Ev Ürünleri",
               CreatedDate = DateTime.Now
            },
            new Category
            {
                Id = 2,
                CategoryName = "Elektronik",
                CreatedDate = DateTime.Now
            });





        }
    }
}
