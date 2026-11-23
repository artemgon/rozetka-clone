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
            NameEn = request.NameEn,
            Description = request.Description,
            DescriptionEn = request.DescriptionEn,
            Sku = request.Sku,
            Price = request.Price,
            OldPrice = request.OldPrice,
            StockQuantity = request.StockQuantity,
            Status = ProductStatus.Active,
            IsFeatured = request.IsFeatured,
            CategoryId = request.CategoryId,
            BrandId = request.BrandId,
            AttributesJson = string.IsNullOrWhiteSpace(request.AttributesJson) ? "{}" : request.AttributesJson
        };

        await productRepository.AddAsync(product, cancellationToken);
        await productRepository.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}