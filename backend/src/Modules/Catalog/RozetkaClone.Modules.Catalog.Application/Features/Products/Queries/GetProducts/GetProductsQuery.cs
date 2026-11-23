using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.DTOs;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProducts;

public record GetProductsQuery(
    string? SearchTerm = null,
    int? CategoryId = null,
    int? BrandId = null,
    decimal? MinPrice = null,
    decimal? MaxPrice = null,
    bool? OnlyDiscounted = null,
    bool? IsFeatured = null,
    string? SortBy = null,
    int PageNumber = 1,
    int PageSize = 20
) : IRequest<PagedResult<ProductDto>>;
