using eshop.API.Models;
using eshop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        //REST: REpresentational State Transfer

        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProducts()
        {
            //IProductService productService = new ProductService();
            var products = productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProductById(id);
            if (product is not null)
            {
                return Ok(product);

            }
            return NotFound();
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search(string name)
        {
            List<Product> products = productService.SearchByName(name);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //sonra...
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = 5 }, null);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            //idempotent -> yan etkisi olmayan fonk.
            return Ok();
        }
    }
}
