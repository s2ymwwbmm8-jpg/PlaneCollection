namespace ConfectioneryFactory.Models;

public class Product : Entity
{
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public Allergens Allergens { get; private set; }

    private Product()
    {
    }

    public static Product Create(string name, decimal price, Allergens allergens)
    {
        var product = new Product();
        product.Update(name, price, allergens);
        return product;
    }

    public void Update(string name, decimal price, Allergens allergens)
    {
        var validName = Guard.NotEmpty(name, "Name");
        var validPrice = Guard.Positive(price, "Price");

        Name = validName;
        Price = validPrice;
        Allergens = allergens;
    }
}
