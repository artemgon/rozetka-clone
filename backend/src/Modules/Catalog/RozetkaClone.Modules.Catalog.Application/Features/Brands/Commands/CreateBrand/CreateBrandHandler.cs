using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.Interfaces;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandHandler(IBrandRepository brandRepository) : IRequestHandler<CreateBrandCommand, int>{
    public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var  brand = new Brand
        {
            Name = request.Name,
            Description = request.Description,
            LogoUrl = request.LogoUrl
        };
        
        await brandRepository.AddAsync(brand, cancellationToken);
        await brandRepository.SaveChangesAsync(cancellationToken);

        return brand.Id;
    }
}