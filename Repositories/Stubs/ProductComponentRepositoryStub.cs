namespace ConfectioneryFactory.Repositories.Stubs;

public class ProductComponentRepositoryStub : IProductComponentRepository
{
    private readonly InMemoryStore<ProductComponent> _store = new();

    public IReadOnlyList<ProductComponent> GetByProductId(int productId) =>
        _store.GetAll().Where(link => link.ProductId == productId).ToList();

    public void Add(ProductComponent link) => _store.Add(link);

    public void Delete(int id) => _store.Delete(id);
}
