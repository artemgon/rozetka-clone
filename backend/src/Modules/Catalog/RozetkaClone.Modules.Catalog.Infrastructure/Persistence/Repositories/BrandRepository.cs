using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RozetkaClone.Modules.Catalog.Application.Interfaces;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Repositories;

public class BrandRepository(CatalogDbContext context) : IBrandRepository
{

    public async Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Brands.ToListAsync(cancellationToken);
    }
    public async Task<Brand?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await context.Brands.FindAsync([id], cancellationToken);
    public async Task AddAsync(Brand brand, CancellationToken cancellationToken = default)
    {
        _ = await context.Brands.AddAsync(brand, cancellationToken);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _ = await context.SaveChangesAsync(cancellationToken);
    }
}
