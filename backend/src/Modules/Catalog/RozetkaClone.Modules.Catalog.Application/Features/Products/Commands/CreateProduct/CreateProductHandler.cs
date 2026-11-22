using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.Interfaces;
using RozetkaClone.Modules.Catalog.Domain.Entities;
using RozetkaClone.Modules.Catalog.Domain.Enums;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Sku = request.Sku,
            Price = request.Price,
            OldPrice = request.OldPrice,
            StockQuantity = request.StockQuantity,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
            Status = ProductStatus.Active,
            AttributesJson = string.IsNullOrWhiteSpace(request.AttributesJson) ? "{}" : request.AttributesJson
        };

        await productRepository.AddAsync(product, cancellationToken);
        await productRepository.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}