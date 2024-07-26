using ChangeTracker.Entities;

namespace ChangeTracker.DataSeed;

public static class DataSeedingConfiguration
{
    public static void ApplyDataSeeding(this ModelBuilder modelBuilder)
    {
        ProductSeeding(modelBuilder);

        ProductCategorySeeding(modelBuilder);
    }

    private static void ProductSeeding(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Product>()
            .HasData(new Product
            {
                Id = 1,
                ProductCategoryId = 1,
                Name = "Smartphone",
                Brand = "Samsung",
                Sku = "ELEC-1234",
                Quantity = 50,
                Price = 1200000,
                Description = null
            });
    }

    private static void ProductCategorySeeding(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ProductCategory>()
            .HasData(new ProductCategory
            {
                Id = 1,
                Title = "Electronics",
                Description = null
            });
    }
}