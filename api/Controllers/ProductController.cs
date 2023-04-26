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

        [HttpPut("{id}/activate")]
        public IActionResult Activate(Guid id)
        {
            _productService.Activate(id);

            return Ok();
        }

        [HttpPut("{id}/description")]
        public IActionResult EditDescription([FromBody] EditDescriptionDto dto)
        {
            var (id, description) = dto;
            var command = new EditDescriptionCommand(id, description);
            _productService.EditDescription(command);

            return Ok();
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
        public IActionResult Find(Guid id)
        {
            ProductDto product = _productRepo.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult RegisterProduct([FromBody] RegisterProductDto dto)
        {
            var (name, description, sku) = dto;
            var command = new RegisterProductCommand(description, name, sku);
            var productId = _productService.Register(command);

            return CreatedAtRoute(nameof(Find), new { id = productId }, null);
        }
    }
}
