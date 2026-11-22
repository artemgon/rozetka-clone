using MediatR;
using Microsoft.AspNetCore.Mvc;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Features.Brands.Commands.CreateBrand;
using RozetkaClone.Modules.Catalog.Application.Features.Brands.Queries.GetBrands;

namespace RozetkaClone.Api.Controllers.Catalog;

[ApiController]
[Route("api/[controller]")]
public class BrandsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<BrandDto>>> GetAll(CancellationToken cancellationToken)
    {
        var brands = await sender.Send(new GetBrandsQuery(), cancellationToken);
        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var brandId = await sender.Send(command, cancellationToken);
        return Ok(brandId);
    }
}

