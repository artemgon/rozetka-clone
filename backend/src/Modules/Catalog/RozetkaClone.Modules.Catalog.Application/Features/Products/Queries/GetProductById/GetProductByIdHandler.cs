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
            product.Id,
            product.Name ?? string.Empty,
            product.Description,
            product.Sku ?? string.Empty,
            product.Price,
            product.OldPrice,
            product.StockQuantity,
            product.Status.ToString(),
            product.BrandId,
            product.Brand.Name,
            product.CategoryId,
            product.Category.Name,
            product.AttributesJson,
            product.CreatedAt);
    }
}
