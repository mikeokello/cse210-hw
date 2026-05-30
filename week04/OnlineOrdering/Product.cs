/// <summary>
/// Represents a product that can be ordered.
/// </summary>
public class Product
{
    private readonly string _name;
    private readonly string _productId;
    private readonly decimal _price;
    private readonly int _quantity;

    /// <summary>
    /// Initializes a new instance of the Product class.
    /// </summary>
    /// <param name="name">The product name.</param>
    /// <param name="productId">The unique product identifier.</param>
    /// <param name="price">The price per unit.</param>
    /// <param name="quantity">The quantity ordered.</param>
    /// <exception cref="ArgumentNullException">Thrown when name or productId is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when price or quantity is negative.</exception>
    public Product(
        string name,
        string productId,
        decimal price,
        int quantity
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Product name cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentNullException(nameof(productId), "Product ID cannot be null or empty.");
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the product ID.
    /// </summary>
    public string ProductId => _productId;

    /// <summary>
    /// Gets the unit price.
    /// </summary>
    public decimal Price => _price;

    /// <summary>
    /// Gets the quantity.
    /// </summary>
    public int Quantity => _quantity;

    /// <summary>
    /// Calculates the total cost for this product (price * quantity).
    /// </summary>
    /// <returns>The total cost as a decimal.</returns>
    public decimal CalculateTotalCost()
    {
        return _price * _quantity;
    }
}