namespace ConfectioneryFactory.Repositories.Stubs;

public class ProductRepositoryStub : IProductRepository
{
    private readonly InMemoryStore<Product> _store = new();

    public IReadOnlyList<Product> GetAll() => _store.GetAll();

    public Product? GetById(int id) => _store.GetById(id);

    public void Add(Product item) => _store.Add(item);

    public void Update(Product item) => _store.Update(item);

    public void Delete(int id) => _store.Delete(id);
}
