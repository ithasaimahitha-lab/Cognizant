using System;

namespace SearchExample
{
    class Program
    {
        static Product? LinearSearch(Product[] products, string item)
        {
            foreach (Product product in products)
            {
                if (product.ProductName.Equals(item, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Phone", "Electronics"),
                new Product(103, "Book", "Education"),
                new Product(104, "Pen", "Stationery"),
                new Product(105, "Bag", "Accessories")
            };

            Console.Write("Enter the item to search: ");
            string item = Console.ReadLine() ?? "";

            Product? result = LinearSearch(products, item);

            if (result != null)
            {
                Console.WriteLine("\nProduct Found");
                Console.WriteLine("Product ID: " + result.ProductId);
                Console.WriteLine("Product Name: " + result.ProductName);
                Console.WriteLine("Category: " + result.Category);
            }
            else
            {
                Console.WriteLine("\nProduct Not Found");
            }
        }
    }
}