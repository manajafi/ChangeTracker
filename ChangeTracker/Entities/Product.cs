using ChangeTracker.Entities.Base;

namespace ChangeTracker.Entities;

public sealed class Product : BaseEntity
{
    public int ProductCategoryId { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string Sku { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public ProductCategory ProductCategory { get; set; }
}