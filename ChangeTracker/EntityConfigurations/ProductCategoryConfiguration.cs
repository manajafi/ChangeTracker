using ChangeTracker.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChangeTracker.EntityConfigurations;

public sealed class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        ConfigureTableName(builder);

        ConfigurePrimaryKeys(builder);

        ConfigureUniqueKeys(builder);

        ConfigureProperties(builder);
    }

    private static void ConfigureTableName(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategory", "inv");
    }

    private static void ConfigurePrimaryKeys(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(p => p.Id);
    }

    private static void ConfigureUniqueKeys(EntityTypeBuilder<ProductCategory> builder)
    {
        builder
            .HasIndex(p => p.Title)
            .IsUnique();
    }

    private static void ConfigureProperties(EntityTypeBuilder<ProductCategory> builder)
    {
        builder
            .Property(p => p.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}