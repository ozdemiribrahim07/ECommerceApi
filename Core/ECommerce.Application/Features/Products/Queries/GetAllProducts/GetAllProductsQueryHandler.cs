using ECommerce.Application.Automapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>()
                .GetAllAsync(include: i => i.Include(i => i.Brand)
                                            .Include(c => c.Category));

            var brand = _mapper.Map<BrandDto,Brand>(new Brand());
            var category = _mapper.Map<CategoryDto,Category>(new Category());

            var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
            {
                item.Price = item.Price - (item.Price * item.Discount) / 100;
            }
            return map;
        }
    }
}
