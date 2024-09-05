using eshop.API.Models;
using eshop.API.Services;
using eshop.Application.Features.Products.Commands.CreateProduct;
using eshop.Application.Features.Products.Commands.UpdateProduct;
using eshop.Application.Features.Products.Queries.GetAllProducts;
using eshop.Application.Features.Products.Queries.GetProduct;
using eshop.Application.Features.Products.Queries.SearchProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        //REST: REpresentational State Transfer

       // private readonly IProductService productService;
        private readonly IMediator mediator;

        public ProductsController( IMediator mediator)
        {
         //   this.productService = productService;
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            //IProductService productService = new ProductService();
            //var products = productService.GetProducts();
            var result = await mediator.Send(new GetAllProductsRequest());
            return Ok(result); 
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var request = new GetProductRequest(id);
            var product = await mediator.Send(request);
            if (product is not null)
            {
                return Ok(product);

            }
            return NotFound();
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            // List<Product> products = productService.SearchByName(name);
            var request = new SearchProductRequest(name);

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Authorize(Roles ="Admin,Editor")]
        public async Task<IActionResult> Create(CreateNewProductRequest product)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = result.Id }, result);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand product)
        {
            //idempotent -> yan etkisi olmayan fonk.
            if (id != product.Id)
            {
                return BadRequest(new { Error = "talep edilen id ile ürün id'si farklı" });
            }
            if (ModelState.IsValid)
            {
                await mediator.Send(product);
                return Ok();
            }
            return BadRequest();
          
        }
         
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //idempotent -> yan etkisi olmayan fonk.
            return Ok();
        }
    }
}
