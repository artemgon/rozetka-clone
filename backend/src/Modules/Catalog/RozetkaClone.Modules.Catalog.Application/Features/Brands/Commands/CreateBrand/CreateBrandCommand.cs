using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RozetkaClone.Modules.Catalog.Application.Features.Brands.Commands.CreateBrand;

public record CreateBrandCommand(
    string Name,
    string? Description,
    string? LogoUrl
) : IRequest<int>;
