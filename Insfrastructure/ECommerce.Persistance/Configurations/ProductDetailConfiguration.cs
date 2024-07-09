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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> b)
        {
           Faker faker = new Faker("tr");

            b.HasData(
                new ProductDetail
                {
                    Id= 1,
                    ProductDetailTitle = faker.Lorem.Sentence(1),
                    ProductDetailDescription = faker.Lorem.Sentence(5),
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new ProductDetail
                {
                    Id = 2,
                    ProductDetailTitle = faker.Lorem.Sentence(1),
                    ProductDetailDescription = faker.Lorem.Sentence(5),
                    CategoryId = 2,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new ProductDetail
                {
                    Id = 3,
                    ProductDetailTitle = faker.Lorem.Sentence(1),
                    ProductDetailDescription = faker.Lorem.Sentence(5),
                    CategoryId = 1,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new ProductDetail
                {
                    Id = 4,
                    ProductDetailTitle = faker.Lorem.Sentence(1),
                    ProductDetailDescription = faker.Lorem.Sentence(5),
                    CategoryId = 2,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
                );
        }
    }
}
