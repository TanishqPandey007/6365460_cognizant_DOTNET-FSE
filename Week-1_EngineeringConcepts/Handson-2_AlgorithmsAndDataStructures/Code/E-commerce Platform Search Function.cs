using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
}

public class Program
{
    static void Main()
    {
        Console.Write("Enter number of products: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Product[] products = new Product[n];

        // User inputs product details
        for (int i = 0; i < n; i++)
        {
            products[i] = new Product();
            Console.Write($"Product {i+1} ID: ");
            products[i].ProductId = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Product {i+1} Name: ");
            products[i].ProductName = Console.ReadLine();
            Console.Write($"Product {i+1} Category: ");
            products[i].Category = Console.ReadLine();
        }

        Console.Write("Enter search ID: ");
        int searchId = Convert.ToInt32(Console.ReadLine());

        // Linear search
        int linearResult = LinearSearch(products, searchId);
        Console.WriteLine(linearResult != -1 
            ? $"Linear search: Found at index {linearResult}" 
            : "Linear search: Not found");

        // Binary search (requires sorting by ProductId)
        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));
        int binaryResult = BinarySearch(products, searchId);
        Console.WriteLine(binaryResult != -1 
            ? $"Binary search: Found at index {binaryResult}" 
            : "Binary search: Not found");
    }

    // Linear search: O(n) complexity
    static int LinearSearch(Product[] products, int searchId)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductId == searchId)
                return i;
        }
        return -1;
    }

    // Binary search: O(log n) complexity
    static int BinarySearch(Product[] products, int searchId)
    {
        int low = 0, high = products.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (products[mid].ProductId == searchId)
                return mid;
            else if (products[mid].ProductId < searchId)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
}
