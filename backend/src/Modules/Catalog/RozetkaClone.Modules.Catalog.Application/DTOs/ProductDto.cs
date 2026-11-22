using System;
using System.Collections.Generic;
using System.Text;

namespace RozetkaClone.Modules.Catalog.Application.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string? Description,
    string Sku,
    decimal Price,
    decimal? OldPrice,
    int StockQuantity,
    string Status,
    int BrandId,
    string BrandName,
    int CategoryId,
    string CategoryName,
    string? AttributesJson,
    DateTime CreatedAt
);