namespace ConfectioneryFactory.Repositories;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();

    Product? GetById(int id);

    void Add(Product item);

    void Update(Product item);

    void Delete(int id);
}
