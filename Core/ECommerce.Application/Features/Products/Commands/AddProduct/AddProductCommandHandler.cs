using ECommerce.Application.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Description = request.Description,
                Discount = request.Discount,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId
            };


            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            var result = await _unitOfWork.SaveAsync();

            if (result > 0)
            {
                return new AddProductCommandResponse
                {
                    Success = true,
                    Message = "Ürün başarılı şekilde eklendi"
                };
            }
            else
            {
                return new AddProductCommandResponse
                {
                    Success = false,
                    Message = "Ürün eklenirken hata oluştu !"
                };
            }
        }
    }

}
