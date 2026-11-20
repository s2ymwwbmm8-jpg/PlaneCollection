namespace ConfectioneryFactory.Repositories;

public interface IProductOrderRepository
{
    IReadOnlyList<ProductOrder> GetAll();

    void Add(ProductOrder item);
}
