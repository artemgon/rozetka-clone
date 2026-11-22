using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace RozetkaClone.Modules.Catalog.Application.Features.Categories.Commands.CreateCategory;
public record CreateCategoryCommand(
    string Name,
    int? ParentCategoryId,
    string? ImageUrl
) : IRequest<int>;
