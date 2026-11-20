namespace ConfectioneryFactory.Repositories.Stubs;

public class ComponentOrderRepositoryStub : IComponentOrderRepository
{
    private readonly InMemoryStore<ComponentOrder> _store = new();

    public IReadOnlyList<ComponentOrder> GetAll() => _store.GetAll();

    public void Add(ComponentOrder item) => _store.Add(item);
}
