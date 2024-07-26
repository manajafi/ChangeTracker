using ChangeTracker.DataSeed;
using ChangeTracker.Entities;
using ChangeTracker.Entities.Base;
using ChangeTracker.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChangeTracker.DatabaseContext;

public class EntityFrameworkContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=.;Initial Catalog=ChangeTrackerDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;")
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetDefaultPropertyValues(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryConfiguration).Assembly);

        modelBuilder.ApplyDataSeeding();
    }

    private static void SetDefaultPropertyValues(ModelBuilder modelBuilder)
    {
        var entityTypes = GetEntityTypes(modelBuilder);

        foreach (var entityType in entityTypes)
        {
            var creationDateTimeProperty = entityType
                .GetProperties()
                .FirstOrDefault(p => p.Name == "CreationDateTime");

            if (creationDateTimeProperty != null && creationDateTimeProperty.ClrType == typeof(DateTime))
                modelBuilder.Entity(entityType.ClrType, typeBuilder =>
                {
                    typeBuilder
                        .Property("CreationDateTime")
                        .HasColumnType("datetime2(7)")
                        .HasDefaultValueSql("GETDATE()");
                });

            var isActiveProperty = entityType
                .GetProperties()
                .FirstOrDefault(p => p.Name == "IsActive");

            if (isActiveProperty != null && isActiveProperty.ClrType == typeof(bool))
                modelBuilder.Entity(entityType.ClrType, typeBuilder =>
                {
                    typeBuilder
                        .Property("IsActive")
                        .HasDefaultValue(true);
                });
        }
    }

    private static IEnumerable<IMutableEntityType> GetEntityTypes(ModelBuilder modelBuilder)
    {
        return modelBuilder
             .Model
             .GetEntityTypes()
             .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity)));
    }

    public DbSet<Product> Product { get; set; }

    public DbSet<ProductCategory> ProductCategory { get; set; }
}