using Api.DataContracts;
using App.Services;
using Catalog.Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPut("activate/{sku}")]
        public IActionResult Activate([FromBody] UpdateProductStatusCommand dto)
        {
            var (id, sku) = dto;
            var command = new UpdateProductStatusCommand(id, sku);

            _catalogProductService.Activate(command);
            return Ok();
        }

        [HttpPut("deactivate/{sku}")]
        public IActionResult Deactivate([FromBody] UpdateProductStatusCommand dto)
        {
            var (id, sku) = dto;
            var command = new UpdateProductStatusCommand(id, sku);

            _catalogProductService.Deactivate(command);
            return Ok();
        }

        [HttpPut("description/{sku}")]
        public IActionResult EditDescription([FromBody] EditDescriptionDto dto)
        {
            var (id, description, sku) = dto;
            var command = new EditDescriptionCommand(id, description, sku);

            _catalogProductService.EditDescription(command);
            return Ok();
        }

        [HttpPut("name/{sku}")]
        public IActionResult EditName([FromBody] EditNameDto dto)
        {
            var (id, name, sku) = dto;
            var command = new EditNameCommand(id, name, sku);

            _catalogProductService.EditName(command);
            return Ok();
        }

        [HttpGet("catalog/{sku}")]
        public IActionResult FindCatalogProduct(string sku)
        {
            var product = _catalogReadService.Find(sku);
            return Ok(product);
        }

        [HttpGet("catalogId/{id}", Name = "FindCatalogProduct")]
        public IActionResult FindCatalogProduct(Guid id)
        {
            var product = _catalogReadService.Find(id);
            return Ok(product);
        }


        [HttpGet("sales/{sku}")]
        public IActionResult FindSalesProduct(string sku)
        {
            var product = _salesReadService.Find(sku);
            return Ok(product);
        }

        [HttpGet("warehouse/{sku}")]
        public IActionResult FindWarehouseProduct(string sku)
        {
            var product = _warehouseReadService.Find(sku);
            return Ok(product);
        }

        [HttpPut("receive/{sku}")]
        public IActionResult ReceiveProducts([FromBody] ReceiveShipProduct dto)
        {
            var (id, qty, sku) = dto;
            var command = new ReceiveShipCommand(id, qty, sku);

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

        [HttpPut("price/{sku}")]
        public IActionResult SetPrice([FromBody] ProductPrice dto)
        {
            var (id, price, sku) = dto;
            var command = new SetPriceCommand(id, price, sku);

            _salesProductService.SetPrice(command);
            return Ok();
        }

        [HttpPut("ship/{sku}")]
        public IActionResult ShipProducts([FromBody] ReceiveShipProduct dto)
        {
            var (id, qty, sku) = dto;
            var command = new ReceiveShipCommand(id, qty, sku);

            _warehouseProductService.Ship(command);
            return Ok();
        }
    }
}