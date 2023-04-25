using api.DataContracts;
using app_services;
using catalog;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductService _productService;

        public ProductController(IProductRepository productRepo, IProductService productService)
        {
            _productRepo = productRepo;
            _productService = productService;
        }

        [HttpPut("{id}/name")]
        public IActionResult EditName([FromBody] EditNameDto dto)
        {
            var (id, name) = dto;
            var command = new EditNameCommand(id, name);
            _productService.EditName(command);

            return Ok();
        }

        [HttpGet("{id}", Name = "Find")]
        public ActionResult<ProductDto> Find(Guid id)
        {
            var product = _productRepo.Find(id);
            var productDto = new ProductDto(product.Name, product.Description, product.Sku);
            return productDto;
        }

        [HttpPost]
        public IActionResult RegisterProduct([FromBody] RegisterProductDto dto)
        {
            var (name, description, sku) = dto;
            var command = new RegisterProductCommand(name, description, sku);
            var productId = _productService.Register(command);

            return CreatedAtRoute(nameof(Find), new { id = productId }, null);
        }
    }
}
