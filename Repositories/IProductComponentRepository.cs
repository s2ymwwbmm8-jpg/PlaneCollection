namespace ConfectioneryFactory.Repositories;

public interface IProductComponentRepository
{
    IReadOnlyList<ProductComponent> GetByProductId(int productId);

    void Add(ProductComponent link);

    void Delete(int id);
}
