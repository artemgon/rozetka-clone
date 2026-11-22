using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RozetkaClone.Modules.Catalog.Domain.Entities;
using RozetkaClone.Modules.Catalog.Infrastructure.Persistence;
using RozetkaClone.Modules.Catalog.Application.Interfaces;

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _сontext;
    public CategoryRepository(CatalogDbContext context)
    {
        _сontext = context;
    }
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _сontext.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _сontext.Categories.FindAsync(new object[] { id }, cancellationToken);
    }
    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _сontext.Categories.AddAsync(category, cancellationToken);
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _сontext.SaveChangesAsync(cancellationToken);
    }

}
