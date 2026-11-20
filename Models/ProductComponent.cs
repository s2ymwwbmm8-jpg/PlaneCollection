namespace ConfectioneryFactory.Models;

public class ProductComponent : Entity
{
    public int ProductId { get; private set; }

    public int ComponentId { get; private set; }

    public decimal Quantity { get; private set; }

    private ProductComponent()
    {
    }

    public static ProductComponent Create(Product product, Component component, decimal quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        ArgumentNullException.ThrowIfNull(component);

        return new ProductComponent
        {
            ProductId = product.Id,
            ComponentId = component.Id,
            Quantity = Guard.Positive(quantity, "Quantity")
        };
    }
}
