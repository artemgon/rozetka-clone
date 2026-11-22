using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.DTOs;
using RozetkaClone.Modules.Catalog.Application.Interfaces;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync(cancellationToken);

        return [..products
            .Select(p => new ProductDto(
                p.Id,
                p.Name ?? string.Empty,
                p.Description,
                p.Sku ?? string.Empty,
                p.Price,
                p.OldPrice,
                p.StockQuantity,
                p.Status.ToString(),
                p.BrandId,
                p.Brand.Name,
                p.CategoryId,
                p.Category.Name,
                p.AttributesJson,
                p.CreatedAt))];
    }
}
