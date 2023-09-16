using Api.DataContracts;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Infrastructure.Read;

namespace Api.Controllers;

[Route("api/[controller]/products")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseProductService _warehouseProductService;
    private readonly IWarehouseReadService _warehouseReadService;

    public WarehouseController(IWarehouseProductService warehouseProductService, IWarehouseReadService warehouseReadService)
    {
        _warehouseProductService = warehouseProductService;
        _warehouseReadService = warehouseReadService;
    }

    [HttpGet("{sku}")]
    public IActionResult Find(string sku)
    {
        var product = _warehouseReadService.Find(sku);
        return Ok(product);
    }

    [HttpPut("{sku}/receive")]
    public IActionResult ReceiveProducts([FromBody] ReceiveShipProduct dto)
    {
        var (qty, sku) = dto;
        var command = new ReceiveShipCommand(qty, sku);

        _warehouseProductService.Receive(command);
        return Ok();
    }

    [HttpPut("{sku}/ship")]
    public IActionResult ShipProducts([FromBody] ReceiveShipProduct dto)
    {
        var (qty, sku) = dto;
        var command = new ReceiveShipCommand(qty, sku);

        _warehouseProductService.Ship(command);
        return Ok();
    }
}