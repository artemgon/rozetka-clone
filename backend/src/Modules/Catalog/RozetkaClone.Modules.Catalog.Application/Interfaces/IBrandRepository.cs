using System;
using System.Collections.Generic;
using System.Text;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Application.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Brand?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Brand brand, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
