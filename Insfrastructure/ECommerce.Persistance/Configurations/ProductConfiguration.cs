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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            
            Faker faker = new Faker("tr");

            b.HasData(
                new Product
                {
                    Id = 1,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    BrandId = 1,
                    Price = faker.Finance.Amount(1, 100)
                },
                new Product
                {
                    Id = 2,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    CategoryId = 2,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Price = faker.Finance.Amount(1, 100),
                    BrandId = 2,
                },
                new Product
                {
                    Id = 3,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    BrandId = 1,
                    Price = faker.Finance.Amount(1, 100)
                },
                new Product
                {
                    Id = 4,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    BrandId = 1,
                    Price = faker.Finance.Amount(1, 100)
                },
                 new Product
                 {
                     Id = 5,
                     Name = faker.Commerce.ProductName(),
                     Description = faker.Commerce.ProductDescription(),
                     CategoryId = 2,
                     CreatedDate = DateTime.Now,
                     IsDeleted = false,
                     BrandId = 2,
                     Price = faker.Finance.Amount(1, 100)
                 }
               );



        }
    }
}
