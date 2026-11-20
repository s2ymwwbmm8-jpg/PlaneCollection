namespace ConfectioneryFactory.Models;

public class ComponentOrder : Entity
{
    public int SupplierId { get; private set; }

    public int ComponentId { get; private set; }

    public decimal Quantity { get; private set; }

    public DateTime OrderDate { get; private set; }

    private ComponentOrder()
    {
    }

    public static ComponentOrder Create(Supplier supplier, Component component, decimal quantity, DateTime orderDate)
    {
        ArgumentNullException.ThrowIfNull(supplier);
        ArgumentNullException.ThrowIfNull(component);

        return new ComponentOrder
        {
            SupplierId = supplier.Id,
            ComponentId = component.Id,
            Quantity = Guard.Positive(quantity, "Quantity"),
            OrderDate = orderDate
        };
    }
}
