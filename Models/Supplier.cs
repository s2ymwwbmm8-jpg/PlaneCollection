namespace ConfectioneryFactory.Models;

public class Supplier : Entity
{
    public string Name { get; private set; } = string.Empty;

    public string Phone { get; private set; } = string.Empty;

    private Supplier()
    {
    }

    public static Supplier Create(string name, string phone)
    {
        var supplier = new Supplier();
        supplier.Update(name, phone);
        return supplier;
    }

    public void Update(string name, string phone)
    {
        var validName = Guard.NotEmpty(name, "Name");
        var validPhone = Guard.NotEmpty(phone, "Phone");

        Name = validName;
        Phone = validPhone;
    }
}
