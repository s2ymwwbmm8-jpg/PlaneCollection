namespace ConfectioneryFactory.Repositories.Stubs;

public class SupplierRepositoryStub : ISupplierRepository
{
    private readonly InMemoryStore<Supplier> _store = new();

    public IReadOnlyList<Supplier> GetAll() => _store.GetAll();

    public Supplier? GetById(int id) => _store.GetById(id);

    public void Add(Supplier item) => _store.Add(item);

    public void Update(Supplier item) => _store.Update(item);

    public void Delete(int id) => _store.Delete(id);
}
