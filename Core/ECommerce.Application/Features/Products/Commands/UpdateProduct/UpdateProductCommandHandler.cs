using ECommerce.Application.Automapper;
using ECommerce.Application.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>()
                .GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            var productCategory = await _unitOfWork.GetReadRepository<Product>()
                .GetAsync(x => x.Id == product.Id && x.IsDeleted == false);

            await _unitOfWork.GetWriteRepository<Product>().HardRemoveAsync(productCategory);
                
            var map = _mapper.Map<Product, UpdateProductCommandRequest>(request);
            
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
        }
    }
}
