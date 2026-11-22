using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.Interfaces;  
using RozetkaClone.Modules.Catalog.Application.DTOs;


namespace RozetkaClone.Modules.Catalog.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsHandler (IBrandRepository brandRepository) : IRequestHandler<GetBrandsQuery, List<BrandDto>>
{
    public async Task<List<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllAsync(cancellationToken);
        return [..brands.Select(b => new BrandDto(b.Id, b.Name, b.Description, b.LogoUrl))];
    }
}
