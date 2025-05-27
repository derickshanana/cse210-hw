public class Address
{
    // Private fields
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Method to check if address is in USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Method to return full address string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}
public class Customer
{
    // Private fields
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if customer is in USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Getter for name
    public string GetName()
    {
        return _name;
    }

    // Getter for address
    public Address GetAddress()
    {
        return _address;
    }
}
public class Product
{
    // Private fields
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate total cost
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    // Getter for name
    public string GetName()
    {
        return _name;
    }

    // Getter for product ID
    public string GetProductId()
    {
        return _productId;
    }
}
public class Order
{
    // Private fields
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add product
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate total cost
    public decimal CalculateTotalCost()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    // Method to get packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Method to get shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        var usaAddress = new Address("123 Main St", "New York", "NY", "USA");
        var canadaAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        var usaCustomer = new Customer("Derick Shanana", usaAddress);
        var canadaCustomer = new Customer("Francina Shanana", canadaAddress);

        // Create products
        var product1 = new Product("Laptop", "P1001", 999.99m, 1);
        var product2 = new Product("Mouse", "P1002", 19.99m, 2);
        var product3 = new Product("Keyboard", "P1003", 49.99m, 1);
        var product4 = new Product("Monitor", "P1004", 199.99m, 2);

        // Create first order (USA customer)
        var order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Create second order (Canada customer)
        var order2 = new Order(canadaCustomer);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product1); // Adding laptop again

        // Display order information
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("=================================");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("=================================\n");
    }
}