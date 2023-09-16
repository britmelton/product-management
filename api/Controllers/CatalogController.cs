using Api.DataContracts;
using App.Services;
using Catalog.Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]/products/")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly ICatalogProductService _catalogProductService;
    private readonly ICatalogReadService _catalogReadService;

    public CatalogController(ICatalogProductService catalogProductService, ICatalogReadService catalogReadService)
    {
        _catalogProductService = catalogProductService;
        _catalogReadService = catalogReadService;
    }

    [HttpPut("{sku}/activate")]
    public IActionResult Activate([FromBody] UpdateProductStatusCommand dto)
    {
        var sku = dto.Sku;
        var command = new UpdateProductStatusCommand(sku);
        _catalogProductService.Activate(command);
        return Ok();
    }

    [HttpPut("{sku}/deactivate")]
    public IActionResult Deactivate([FromBody] UpdateProductStatusCommand dto)
    {
        var sku = dto.Sku;
        var command = new UpdateProductStatusCommand(sku);

        _catalogProductService.Deactivate(command);
        return Ok();
    }

    [HttpPut("{sku}/description")]
    public IActionResult EditDescription([FromBody] EditDescriptionDto dto)
    {
        var (description, sku) = dto;
        var command = new EditDescriptionCommand(description, sku);

        _catalogProductService.EditDescription(command);
        return Ok();
    }

    [HttpPut("{sku}/name")]
    public IActionResult EditName([FromBody] EditNameDto dto)
    {
        var (name, sku) = dto;
        var command = new EditNameCommand(name, sku);

        _catalogProductService.EditName(command);
        return Ok();
    }

    [HttpGet("{sku}", Name = "Find")]
    public IActionResult Find(string sku)
    {
        var product = _catalogReadService.Find(sku);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult RegisterProduct([FromBody] RegisterProduct dto)
    {
        var (name, description, sku) = dto;
        var command = new RegisterProductCommand(description, name, sku);

         _catalogProductService.Register(command);
        return CreatedAtRoute("Find", new { sku }, null);
    }
}

