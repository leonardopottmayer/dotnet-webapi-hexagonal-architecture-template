using HexagonalArchitecture.Domain.Adapters.Rest;
using HexagonalArchitecture.Domain.Adapters.UserProvider;
using HexagonalArchitecture.Domain.Exceptions;
using HexagonalArchitecture.Domain.Models.ProductModels;
using HexagonalArchitecture.Logic.Cqrs.ProductCqrs.Definitions.Crud;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Adapter.Rest.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : DefaultController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserReference _userReference;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator, IUserReference userReference, IHttpContextAccessor httpContextAccessor) : base(userReference, httpContextAccessor)
        {
            _mediator = mediator;
            _userReference = userReference;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ISuccessApiResponse<FetchResult<ProductDto>>))]
        public async Task<IActionResult> GetAllProducts()
        {
            var cmd = new GetAllProductsCommand();

            var result = await _mediator.Send(cmd);

            var responseObject = new FetchResult<ProductDto>()
            {
                Entities = result
            };

            return Ok(responseObject);
        }

        [HttpGet("paged")]
        [ProducesResponseType(200, Type = typeof(ISuccessApiResponse<FetchPageResult<ProductDto>>))]
        public async Task<IActionResult> GetAllProductsPaged([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var cmd = new GetAllProductsPagedCommand()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _mediator.Send(cmd);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(ISuccessApiResponse<FetchSingleResult<ProductDto>>))]
        public async Task<IActionResult> GetProductById(long productId)
        {
            var cmd = new GetProductByIdCommand()
            {
                Id = productId
            };

            var result = await _mediator.Send(cmd);

            if (result == null)
                throw new KeyNotFoundException();

            var responseObject = new FetchSingleResult<ProductDto>()
            {
                Entity = result
            };

            return Ok(responseObject);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(200, Type = typeof(ISuccessApiResponse<bool>))]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var cmd = new DeleteProductCommand()
            {
                Id = productId
            };

            var result = await _mediator.Send(cmd);

            if (result == false)
                throw new BusinessException(6);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ISuccessApiResponse<long>))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto product)
        {
            var cmd = new CreateProductCommand()
            {
                Product = product
            };

            var result = await _mediator.Send(cmd);

            if (result < 1)
                throw new BusinessException(5);

            return Ok(result);
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(200, Type = typeof(ISuccessApiResponse<bool>))]
        public async Task<IActionResult> UpdateProduct(long productId, [FromBody] UpdateProductDto product)
        {
            var cmd = new UpdateProductCommand()
            {
                Product = product,
                ProductId = productId
            };

            var result = await _mediator.Send(cmd);

            if (!result)
                throw new BusinessException(7);

            return Ok(result);
        }
    }
}

