using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RozetkaClone.Modules.Catalog.Application.DTOs;

namespace RozetkaClone.Modules.Catalog.Application.Features.Brands.Queries.GetBrands;

public record GetBrandsQuery : IRequest<List<BrandDto>>;    