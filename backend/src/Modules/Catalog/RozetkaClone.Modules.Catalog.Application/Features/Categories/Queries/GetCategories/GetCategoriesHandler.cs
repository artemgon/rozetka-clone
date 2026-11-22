using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.Interfaces;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var allCategories = await _categoryRepository.GetAllAsync(cancellationToken);
        return BuildTree(allCategories, null);
    }

    private static List<CategoryDto> BuildTree(List<Category> categories, int? parentId)
    {
        return categories
            .Where(c => c.ParentCategoryId == parentId)
            .Select(c => new CategoryDto(
                c.Id,
                c.Name,
                c.ParentCategoryId,
                c.ImageUrl,
                BuildTree(categories, c.Id)
            ))
            .ToList();
    }
}