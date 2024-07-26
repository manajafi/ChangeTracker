using ChangeTracker.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChangeTracker.EntityConfigurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureTableName(builder);

        ConfigureTableTemporal(builder);

        ConfigurePrimaryKeys(builder);

        ConfigureUniqueKeys(builder);

        ConfigureProperties(builder);

        ConfigureRelationships(builder);
    }

    private static void ConfigureTableName(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "inv");
    }

    private static void ConfigureTableTemporal(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), p => p.IsTemporal());
    }

    private static void ConfigurePrimaryKeys(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasIndex(p => p.Sku)
            .IsUnique();
    }

    private static void ConfigureProperties(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Brand)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Quantity)
            .IsRequired();

        builder
            .Property(p => p.Sku)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired(false);
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(p => p.ProductCategory)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}