using MediatR;
using Microsoft.AspNetCore.Mvc;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Features.Categories.Commands.CreateCategory;
using RozetkaClone.Modules.Catalog.Application.Features.Categories.Queries.GetCategories;

namespace RozetkaClone.Api.Controllers.Catalog;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCategoriesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var categoryId = await _sender.Send(command, cancellationToken);
        return Ok(categoryId);
    }
}