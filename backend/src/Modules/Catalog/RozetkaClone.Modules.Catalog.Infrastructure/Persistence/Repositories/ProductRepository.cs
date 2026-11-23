using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RozetkaClone.Modules.Catalog.Domain.Entities;
using RozetkaClone.Modules.Catalog.Application.Interfaces;

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Repositories;

public class ProductRepository(CatalogDbContext context) : IProductRepository
{
    public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(
        string? searchTerm = null,
        int? categoryId = null,
        int? brandId = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        bool? onlyDiscounted = null,
        bool? isFeatured = null,
        string? sortBy = null,
        int pageNumber = 1,
        int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var query = context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim().ToLower();
            query = query.Where(p =>
                p.Name != null && p.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                (p.NameEn != null && p.NameEn.Contains(term, StringComparison.CurrentCultureIgnoreCase)) ||
                (p.Description != null && p.Description.Contains(term, StringComparison.CurrentCultureIgnoreCase)) ||
                (p.Sku != null && p.Sku.Contains(term, StringComparison.CurrentCultureIgnoreCase)));
        }
        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);
        
        if (brandId.HasValue)
            query = query.Where(p => p.BrandId == brandId.Value);
        
        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);
        
        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);
        
        if (onlyDiscounted == true)
            query = query.Where(p => p.OldPrice != null && p.OldPrice > p.Price);

        if (isFeatured == true)
            query = query.Where(p => p.IsFeatured);

        query = sortBy?.ToLower() switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "rating" => query.OrderByDescending(p => p.AverageRating),
            "reviews_count" => query.OrderByDescending(p => p.ReviewsCount),
            "popular" => query.OrderByDescending(p => p.SalesCount),
            _ => query.OrderByDescending(p => p.CreatedAt)
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Product?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
    }

    public void Remove(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
