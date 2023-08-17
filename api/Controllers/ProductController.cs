using Api.DataContracts;
using App.Services;
using Catalog.Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;
using Sales.Infrastructure.Read;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICatalogProductService _catalogProductService;
        private readonly ISalesProductService _salesProductService;
        private readonly ICatalogReadService _catalogReadService;
        private readonly ISalesReadService _salesReadService;

        public ProductController(ICatalogProductService catalogProductService, ICatalogReadService catalogReadService, ISalesProductService salesProductService, ISalesReadService salesReadService
        )
        {
            _catalogProductService = catalogProductService;
            _catalogReadService = catalogReadService;
        }

        [HttpPut("{id}/activate")]
        public IActionResult Activate(Guid id)
        {
            _catalogProductService.Activate(id);

            return Ok();
        }

        [HttpPut("{id}/deactivate")]
        public IActionResult Deactivate(Guid id)
        {
            _catalogProductService.Deactivate(id);

            return Ok();
        }

        [HttpPut("{id}/description")]
        public IActionResult EditDescription([FromBody] EditDescriptionDto dto)
        {
            var (id, description) = dto;
            var command = new EditDescriptionCommand(id, description);
            _catalogProductService.EditDescription(command);

            return Ok();
        }

        [HttpPut("{id}/name")]
        public IActionResult EditName([FromBody] EditNameDto dto)
        {
            var (id, name) = dto;
            var command = new EditNameCommand(id, name);
            _catalogProductService.EditName(command);

            return Ok();
        }

        [HttpGet("{id}", Name = "Find")]
        public IActionResult Find(Guid id)
        {
            var product = _catalogReadService.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult RegisterProduct([FromBody] RegisterProduct dto)
        {
            var (name, description, sku) = dto;
            var command = new RegisterProductCommand(description, name, sku);
            var productId = _catalogProductService.Register(command);

            return CreatedAtRoute(nameof(Find), new { id = productId }, null);
        }

        [HttpPut("{id}/price")]
        public IActionResult SetPrice([FromBody] SetProductPrice dto)
        {
            var (id, price) = dto;
            var command = new ProductPriceCommand(id, price);

            _salesProductService.SetPrice(command);

            return Ok();
        }
    }
}