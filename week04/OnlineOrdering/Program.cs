using System;

class Product
{
    public string Name { get; set; }
    public string ProductID { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Constructor to initialize product details
    public Product(string name, string productID, double price, int quantity)
    {
        Name = name;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}

// Address class to represent the customer's address
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    // Constructor to initialize address details
    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.ToUpper() == "USA";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

// Customer class to represent the customer
class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    // Constructor to initialize customer details
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Method to check if the customer lives in the USA
    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}

// Order class to represent the order
class Order
{
    private List<Product> products;
    private Customer customer;
    private double shippingCost;

    // Constructor to initialize the order
    public Order(Customer customer)
    {
        products = new List<Product>();
        this.customer = customer;
        shippingCost = customer.LivesInUSA() ? 5.0 : 35.0; // $5 for USA, $35 for international
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total price of the order
    public double CalculateTotalPrice()
    {
        double total = shippingCost;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }

    // Method to get the packing label (product name and ID)
    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"Product: {product.Name}, ID: {product.ProductID}\n";
        }
        return label;
    }

    // Method to get the shipping label (customer name and address)
    public string GetShippingLabel()
    {
        return $"Customer: {customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // Create some product instances
        Product product1 = new Product("Laptop", "P123", 1200.00, 1);
        Product product2 = new Product("Headphones", "P456", 100.00, 2);

        // Create an address for the customer
        Address address = new Address("123 Main St", "Springfield", "IL", "USA");

        // Create a customer
        Customer customer = new Customer("John Doe", address);

        // Create an order for the customer
        Order order = new Order(customer);

        // Add products to the order
        order.AddProduct(product1);
        order.AddProduct(product2);

        // Display the packing label, shipping label, and total price
        Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");


    }
}