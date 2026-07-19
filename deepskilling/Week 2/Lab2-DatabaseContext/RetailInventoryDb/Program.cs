using Microsoft.EntityFrameworkCore;
using RetailInventoryDb;

Console.WriteLine("===== LAB 7 : LINQ Queries =====");

await using var context = new AppDbContext();

var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("\nFiltered and Sorted Products:");

foreach (var product in filtered)
{
    Console.WriteLine($"{product.Name} - ₹{product.Price}");
}

var productDTOs = await context.Products
    .Select(p => new
    {
        p.Name,
        p.Price
    })
    .ToListAsync();

Console.WriteLine("\nProjected DTO Data:");

foreach (var dto in productDTOs)
{
    Console.WriteLine($"{dto.Name} - ₹{dto.Price}");
}