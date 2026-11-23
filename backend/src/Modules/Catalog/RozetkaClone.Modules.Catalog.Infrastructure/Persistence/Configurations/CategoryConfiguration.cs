using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RozetkaClone.Modules.Catalog.Domain.Entities;

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.NameEn)
            .HasMaxLength(150);

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(500);

        // Self-referencing relationship for parent-child categories
        builder.HasOne(c => c.ParentCategory)
               .WithMany(c => c.SubCategories)
               .HasForeignKey(c => c.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes to avoid accidental deletion of subcategories
    }
}
