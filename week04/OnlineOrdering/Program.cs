using System;

class Product
{
    public string Name { get; set; }
    public string ProductID { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }


    public Product(string name, string productID, double price, int quantity)
    {
        Name = name;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }


    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}


class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }


    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }


    public bool IsInUSA()
    {
        return Country.ToUpper() == "USA";
    }


    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}


class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }


    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }


    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}


class Order
{
    private List<Product> products;
    private Customer customer;
    private double shippingCost;


    public Order(Customer customer)
    {
        products = new List<Product>();
        this.customer = customer;
        shippingCost = customer.LivesInUSA() ? 5.0 : 35.0;
    }


    public void AddProduct(Product product)
    {
        products.Add(product);
    }


    public double CalculateTotalPrice()
    {
        double total = shippingCost;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }


    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"Product: {product.Name}, ID: {product.ProductID}\n";
        }
        return label;
    }


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


        Product product1 = new Product("Laptop", "P123", 1200.00, 1);
        Product product2 = new Product("Headphones", "P456", 100.00, 2);


        Address address = new Address("123 Main St", "Springfield", "IL", "USA");


        Customer customer = new Customer("John Doe", address);


        Order order = new Order(customer);


        order.AddProduct(product1);
        order.AddProduct(product2);


        Console.WriteLine("Packing Label:\n" + order.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");


    }
}