using System;

/// <summary>
/// Main entry point for the Online Ordering application.
/// Demonstrates creating orders with products and displaying order information.
/// </summary>
class Program
{
    /// <summary>
    /// Main method that creates sample orders and displays their information.
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            // First customer and address (USA)
            Address address1 = new Address(
                "123 Main Street",
                "New York",
                "NY",
                "USA"
            );

            Customer customer1 = new Customer(
                "John Smith",
                address1
            );

            // Products for first order
            Product product1 = new Product(
                "Laptop",
                "P1001",
                800m,
                1
            );

            Product product2 = new Product(
                "Mouse",
                "P1002",
                25m,
                2
            );

            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            // Second customer and address (Outside USA)
            Address address2 = new Address(
                "45 Kampala Road",
                "Kampala",
                "Central Region",
                "Uganda"
            );

            Customer customer2 = new Customer(
                "George Mike Okello",
                address2
            );

            // Products for second order
            Product product3 = new Product(
                "Phone",
                "P2001",
                450m,
                1
            );

            Product product4 = new Product(
                "Headphones",
                "P2002",
                50m,
                2
            );

            Product product5 = new Product(
                "Charger",
                "P2003",
                20m,
                1
            );

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            // Display orders
            DisplayOrder(1, order1);
            DisplayOrder(2, order2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays order information including packing label, shipping label, and total cost.
    /// </summary>
    /// <param name="orderNumber">The order number to display.</param>
    /// <param name="order">The order to display.</param>
    private static void DisplayOrder(int orderNumber, Order order)
    {
        Console.WriteLine($"========== ORDER {orderNumber} ==========");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
        Console.WriteLine();
    }
}