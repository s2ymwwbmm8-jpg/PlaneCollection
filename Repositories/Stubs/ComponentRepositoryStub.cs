namespace ConfectioneryFactory.Repositories.Stubs;

public class ComponentRepositoryStub : IComponentRepository
{
    private readonly InMemoryStore<Component> _store = new();

    public IReadOnlyList<Component> GetAll() => _store.GetAll();

    public Component? GetById(int id) => _store.GetById(id);

    public void Add(Component item) => _store.Add(item);

    public void Update(Component item) => _store.Update(item);

    public void Delete(int id) => _store.Delete(id);
}
