/// <summary>
/// Represents a physical address with street, city, state/province, and country.
/// </summary>
public class Address
{
    private readonly string _streetAddress;
    private readonly string _city;
    private readonly string _stateProvince;
    private readonly string _country;

    /// <summary>
    /// Initializes a new instance of the Address class.
    /// </summary>
    /// <param name="streetAddress">The street address.</param>
    /// <param name="city">The city name.</param>
    /// <param name="stateProvince">The state or province name.</param>
    /// <param name="country">The country name.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null or empty.</exception>
    public Address(
        string streetAddress,
        string city,
        string stateProvince,
        string country
    )
    {
        if (string.IsNullOrWhiteSpace(streetAddress))
            throw new ArgumentNullException(nameof(streetAddress), "Street address cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentNullException(nameof(city), "City cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(stateProvince))
            throw new ArgumentNullException(nameof(stateProvince), "State/Province cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentNullException(nameof(country), "Country cannot be null or empty.");

        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    /// <summary>
    /// Gets a value indicating whether the address is in the USA.
    /// </summary>
    public bool IsInUSA => _country.Equals("USA", System.StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Gets the complete formatted address.
    /// </summary>
    public string FullAddress =>
        $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
}