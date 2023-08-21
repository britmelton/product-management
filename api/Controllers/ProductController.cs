using Api.DataContracts;
using App.Services;
using Catalog.Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;
using Sales.Infrastructure.Read;
using Warehouse.Infrastructure.Read;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICatalogProductService _catalogProductService;
        private readonly ICatalogReadService _catalogReadService;
        private readonly ISalesProductService _salesProductService;
        private readonly ISalesReadService _salesReadService;
        private readonly IWarehouseProductService _warehouseProductService;
        private readonly IWarehouseReadService _warehouseReadService;

        public ProductController(
            ICatalogProductService catalogProductService, ICatalogReadService catalogReadService, 
            ISalesProductService salesProductService, ISalesReadService salesReadService, 
            IWarehouseProductService warehouseProductService, IWarehouseReadService warehouseReadService
            )
        {
            _catalogProductService = catalogProductService;
            _catalogReadService = catalogReadService;
            _salesProductService = salesProductService;
            _salesReadService = salesReadService;
            _warehouseProductService = warehouseProductService;
            _warehouseReadService = warehouseReadService;
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

        [HttpGet("catalog/{id}", Name = "FindCatalogProduct")]
        public IActionResult FindCatalogProduct(Guid id)
        {
            var product = _catalogReadService.Find(id);
            return Ok(product);
        }

        [HttpGet("sales/{id}")]
        public IActionResult FindSalesProduct(Guid id)
        {
            var product = _salesReadService.Find(id);
            return Ok(product);
        }

        [HttpGet("warehouse/{id}")]
        public IActionResult FindWarehouseProduct(Guid id)
        {
            var product = _warehouseReadService.Find(id);
            return Ok(product);
        }

        [HttpPut("receive/{id}")]
        public IActionResult ReceiveProducts([FromBody] ReceiveShipProduct dto)
        {
            var (id, qty) = dto;
            var command = new ReceiveShipCommand(id, qty);

            _warehouseProductService.Receive(command);
            return Ok();
        }

        [HttpPost]
        public IActionResult RegisterProduct([FromBody] RegisterProduct dto)
        {
            var (name, description, sku) = dto;
            var command = new RegisterProductCommand(description, name, sku);

            var productId = _catalogProductService.Register(command);
            return CreatedAtRoute(nameof(FindCatalogProduct), new { id = productId }, null);
        }

        [HttpPut("{id}/price")]
        public IActionResult SetPrice([FromBody] ProductPrice dto)
        {
            var (id, price, sku) = dto;
            var command = new SetPriceCommand(id, price, sku);

            _salesProductService.SetPrice(command);
            return Ok();
        }

        [HttpPut("ship/{id}")]
        public IActionResult ShipProducts([FromBody] ReceiveShipProduct dto)
        {
            var (id, qty) = dto;
            var command = new ReceiveShipCommand(id, qty);

            _warehouseProductService.Ship(command);
            return Ok();
        }
    }
}