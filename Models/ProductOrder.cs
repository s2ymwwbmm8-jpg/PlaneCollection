namespace ConfectioneryFactory.Models;

public class ProductOrder : Entity
{
    public int ProductId { get; private set; }

    public int Quantity { get; private set; }

    public DateTime OrderDate { get; private set; }

    public decimal Amount { get; private set; }

    private ProductOrder()
    {
    }

    public static ProductOrder Create(Product product, int quantity, DateTime orderDate)
    {
        ArgumentNullException.ThrowIfNull(product);
        Guard.Positive(quantity, "Quantity");

        return new ProductOrder
        {
            ProductId = product.Id,
            Quantity = quantity,
            OrderDate = orderDate,
            Amount = product.Price * quantity
        };
    }
}
