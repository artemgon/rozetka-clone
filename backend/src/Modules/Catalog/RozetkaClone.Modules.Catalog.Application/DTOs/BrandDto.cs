using System;
using System.Collections.Generic;
using System.Text;

namespace RozetkaClone.Modules.Catalog.Application.DTOs;

public record BrandDto(
    int Id,
    string Name,
    string? Description,
    string? LogoUrl
);

