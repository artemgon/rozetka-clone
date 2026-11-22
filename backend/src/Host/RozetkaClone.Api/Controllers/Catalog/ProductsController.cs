using MediatR;
using Microsoft.AspNetCore.Mvc;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProductById;
using RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProducts;
using RozetkaClone.Modules.Catalog.Application.Features.Products.Commands.CreateProduct;

namespace RozetkaClone.Api.Controllers.Catalog;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await sender.Send(new GetProductsQuery(), cancellationToken);
        return Ok(products);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await sender.Send(new GetProductByIdQuery(id), cancellationToken);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        var productId = await sender.Send(command, cancellationToken);
        return Ok(productId);
    }
}
