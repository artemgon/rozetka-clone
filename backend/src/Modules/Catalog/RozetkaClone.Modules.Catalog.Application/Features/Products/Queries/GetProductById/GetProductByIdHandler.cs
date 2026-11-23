using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Interfaces;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            return null;
        }
        return new ProductDto(
            Id: product.Id,
            Name: product.Name ?? string.Empty,
            NameEn: product.NameEn ?? string.Empty,
            Description: product.Description,
            DescriptionEn: product.DescriptionEn,
            Sku: product.Sku ?? string.Empty,
            Price: product.Price,
            OldPrice: product.OldPrice,
            StockQuantity: product.StockQuantity,
            SalesCount: product.SalesCount,
            IsFeatured: product.IsFeatured,
            AverageRating: product.AverageRating,
            ReviewsCount: product.ReviewsCount,
            Status: product.Status.ToString(),
            BrandId: product.BrandId,
            BrandName: product.Brand.Name,
            CategoryId: product.CategoryId,
            CategoryName: product.Category.Name,
            AttributesJson: product.AttributesJson,
            CreatedAt: product.CreatedAt);
    }
}
