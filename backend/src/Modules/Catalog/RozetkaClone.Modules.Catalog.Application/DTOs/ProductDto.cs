using System;
using System.Collections.Generic;
using System.Text;

namespace RozetkaClone.Modules.Catalog.Application.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string NameEn,
    string? Description,
    string? DescriptionEn,
    string Sku,
    decimal Price,
    decimal? OldPrice,
    int StockQuantity,
    string Status,
    double AverageRating,
    int ReviewsCount,
    int SalesCount,
    bool IsFeatured,
    int BrandId,
    string BrandName,
    int CategoryId,
    string CategoryName,
    string? AttributesJson,
    DateTime CreatedAt
);