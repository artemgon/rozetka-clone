using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Interfaces;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    public async Task<PagedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
        var pageSize = request.PageSize is < 1 or > 100 ? 20 : request.PageSize;

        var (products, totalCount) = await productRepository.GetPagedAsync(
            request.SearchTerm,
            request.CategoryId,
            request.BrandId,
            request.MinPrice,
            request.MaxPrice,
            request.OnlyDiscounted,
            request.IsFeatured,
            request.SortBy,
            pageNumber,
            pageSize,
            cancellationToken);

        var dtos = products
            .Select(p => new ProductDto(
            Id: p.Id,
            Name: p.Name ?? string.Empty,
            NameEn: p.NameEn ?? string.Empty,
            Description: p.Description,
            DescriptionEn: p.DescriptionEn,
            Sku: p.Sku ?? string.Empty,
            Price: p.Price,
            OldPrice: p.OldPrice,
            StockQuantity: p.StockQuantity,
            Status: p.Status.ToString(),
            AverageRating: p.AverageRating,
            ReviewsCount: p.ReviewsCount,
            SalesCount: p.SalesCount,
            IsFeatured: p.IsFeatured,
            BrandId: p.BrandId,
            BrandName: p.Brand.Name,
            CategoryId: p.CategoryId,
            CategoryName: p.Category.Name,
            AttributesJson: p.AttributesJson,
            CreatedAt: p.CreatedAt))
        .ToList();
    
        return new PagedResult<ProductDto>(dtos, totalCount, pageNumber, pageSize);
    }
}
