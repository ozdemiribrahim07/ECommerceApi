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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> b)
        {
            Faker faker = new Faker("tr");

            b.HasData(
                new Brand
                {
                    Id = 1,
                    BrandName = faker.Commerce.Department(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Brand
                {
                    Id = 2,
                    BrandName = faker.Commerce.Department(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false

                },
                new Brand
                {
                    Id = 3,
                    BrandName = faker.Commerce.Department(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
                );


        }
    }
}
