using System;
using System.Collections.Generic;
using System.Text;

namespace RozetkaClone.Modules.Catalog.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int StockQuantity { get; set; }
        public string Brand { get; set; } = string.Empty;

        // Foreign key for the category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Flexible properties in JSON format
        public string? AttributesJson { get; set; } = "{}";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Product images gallery
        public ICollection<ProductImage> Images { get; set; } = [];
    }
}
