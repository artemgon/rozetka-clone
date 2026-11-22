using System;
using System.Collections.Generic;
using System.Text;

namespace RozetkaClone.Modules.Catalog.Application.DTOs;

public record CategoryDto(
    int Id,
    string Name,
    int? ParentCategoryId,
    string? ImageUrl,
    List<CategoryDto> Children
);