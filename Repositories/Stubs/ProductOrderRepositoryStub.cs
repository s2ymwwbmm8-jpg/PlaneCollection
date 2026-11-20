namespace ConfectioneryFactory.Repositories.Stubs;

public class ProductOrderRepositoryStub : IProductOrderRepository
{
    private readonly InMemoryStore<ProductOrder> _store = new();

    public IReadOnlyList<ProductOrder> GetAll() => _store.GetAll();

    public void Add(ProductOrder item) => _store.Add(item);
}
