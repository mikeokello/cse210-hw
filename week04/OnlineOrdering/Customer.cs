/// <summary>
/// Represents a customer with a name and address.
/// </summary>
public class Customer
{
    private readonly string _name;
    private readonly Address _address;

    /// <summary>
    /// Initializes a new instance of the Customer class.
    /// </summary>
    /// <param name="name">The customer's name.</param>
    /// <param name="address">The customer's address.</param>
    /// <exception cref="ArgumentNullException">Thrown when name is null/empty or address is null.</exception>
    public Customer(
        string name,
        Address address
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Customer name cannot be null or empty.");
        if (address == null)
            throw new ArgumentNullException(nameof(address), "Address cannot be null.");

        _name = name;
        _address = address;
    }

    /// <summary>
    /// Gets the customer's name.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the customer's address.
    /// </summary>
    public Address Address => _address;

    /// <summary>
    /// Gets a value indicating whether the customer lives in the USA.
    /// </summary>
    public bool LivesInUSA => _address.IsInUSA;
}