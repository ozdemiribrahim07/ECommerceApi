using ECommerce.Application.Features.Products.Commands.AddProduct;
using ECommerce.Application.Features.Products.Commands.DeleteProduct;
using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]AddProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


    }
}
