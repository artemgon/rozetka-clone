using System;
using System.Collections.Generic;
using System.Text;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Application.Interfaces;

public interface IProductRepository
{
    Task<(List<Product> Items, int TotalCount)> GetPagedAsync(
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
        CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdForUpdateAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    void Remove(Product product);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
