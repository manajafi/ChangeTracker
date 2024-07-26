using ChangeTracker.Entities.Base;

namespace ChangeTracker.Entities;

public sealed class ProductCategory : BaseEntity
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; }
}