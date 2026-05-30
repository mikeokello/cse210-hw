using System;
using System.Collections.Generic;

/// <summary>
/// Represents an order containing products for a specific customer.
/// </summary>
public class Order
{
    private const decimal USA_SHIPPING = 5m;
    private const decimal INTERNATIONAL_SHIPPING = 35m;

    private readonly List<Product> _products;
    private readonly Customer _customer;

    /// <summary>
    /// Initializes a new instance of the Order class.
    /// </summary>
    /// <param name="customer">The customer placing the order.</param>
    /// <exception cref="ArgumentNullException">Thrown when customer is null.</exception>
    public Order(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");

        _customer = customer;
        _products = new List<Product>();
    }

    /// <summary>
    /// Adds a product to the order.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when product is null.</exception>
    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");

        _products.Add(product);
    }

    /// <summary>
    /// Calculates the total cost of the order including shipping.
    /// </summary>
    /// <returns>The total cost as a decimal.</returns>
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.CalculateTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA ? USA_SHIPPING : INTERNATIONAL_SHIPPING;
        totalCost += shippingCost;

        return totalCost;
    }

    /// <summary>
    /// Gets the packing label for the order.
    /// </summary>
    /// <returns>A formatted string containing product information.</returns>
    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product product in _products)
        {
            label += $"Product Name: {product.Name}\n";
            label += $"Product ID: {product.ProductId}\n\n";
        }

        return label;
    }

    /// <summary>
    /// Gets the shipping label for the order.
    /// </summary>
    /// <returns>A formatted string containing customer shipping information.</returns>
    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.FullAddress}";
    }
}