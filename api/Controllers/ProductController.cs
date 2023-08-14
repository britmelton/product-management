using api.DataContracts;
using app_services;
using catalog.infrastructure.read;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductReadService _productReadService;

        public ProductController(IProductService productService, IProductReadService productReadService)
        {
            _productService = productService;
            _productReadService = productReadService;
        }

        [HttpPut("{id}/activate")]
        public IActionResult Activate(Guid id)
        {
            _productService.Activate(id);

            return Ok();
        }

        [HttpPut("{id}/deactivate")]
        public IActionResult Deactivate(Guid id)
        {
            _productService.Deactivate(id);

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
            catalog.infrastructure.read.ProductDto product = _productReadService.Find(id);
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
