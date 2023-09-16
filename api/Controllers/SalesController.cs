using Api.DataContracts;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Sales.Infrastructure.Read;

namespace Api.Controllers;

[Route("api/[controller]/products")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISalesProductService _salesProductService;
    private readonly ISalesReadService _salesReadService;

    public SalesController(ISalesProductService salesProductService, ISalesReadService salesReadService)
    {
        _salesProductService = salesProductService;
        _salesReadService = salesReadService;
    }

    [HttpGet("{sku}")]
    public IActionResult Find(string sku)
    {
        var product = _salesReadService.Find(sku);
        return Ok(product);
    }

    [HttpPut("{sku}/price")]
    public IActionResult SetPrice([FromBody] ProductPrice dto)
    {
        var (price, sku) = dto;
        var command = new SetPriceCommand(price, sku);

        _salesProductService.SetPrice(command);
        return Ok();
    }
}

