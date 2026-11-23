using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RozetkaClone.Modules.Catalog.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string? NameEn,
    string? Description,
    string? DescriptionEn,
    string Sku,
    decimal Price,
    decimal? OldPrice,
    int StockQuantity,
    bool IsFeatured,
    int BrandId,
    int CategoryId,
    string? AttributesJson
) : IRequest<int>;