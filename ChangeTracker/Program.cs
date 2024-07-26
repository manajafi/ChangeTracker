using ChangeTracker.Entities;

var entityFrameworkContext = new EntityFrameworkContext();

var newProductCategory = new Product
{
    ProductCategoryId = 1,
    Name = "Camera",
    Brand = "Nikon",
    Quantity = 45,
    Price = 1780000,
    Sku = "ELEC-6547",
    Description = null
};

await entityFrameworkContext
    .Product
    .AddAsync(newProductCategory);

await entityFrameworkContext.SaveChangesAsync();

newProductCategory.Name = "Camera_New";

entityFrameworkContext
    .Product
    .Update(newProductCategory);

await entityFrameworkContext.SaveChangesAsync();

var allProducts = entityFrameworkContext.Product
    .OrderBy(p => EF.Property<DateTime>(p, "PeriodStart"))
    .Where(p => p.Name == "Camera_New")
    .Select(p =>
        new
        {
            Product = p,
            PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
            PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
        })
    .ToList();

foreach (var product in allProducts)
    Console.WriteLine($"Product: {product.Product.Name} | " +
                      $"PeriodStart: {product.PeriodStart} | " +
                      $"PeriodEnd: {product.PeriodEnd}");