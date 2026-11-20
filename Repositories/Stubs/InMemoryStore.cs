namespace ConfectioneryFactory.Repositories.Stubs;

internal class InMemoryStore<T> where T : Entity
{
    private readonly List<T> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<T> GetAll() => _items.ToList();

    public T? GetById(int id) => _items.FirstOrDefault(item => item.Id == id);

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        item.AssignId(_nextId++);
        _items.Add(item);
    }

    public void Update(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var index = _items.FindIndex(existing => existing.Id == item.Id);
        if (index < 0)
        {
            throw new KeyNotFoundException($"Record with id {item.Id} was not found.");
        }

        _items[index] = item;
    }

    public void Delete(int id) => _items.RemoveAll(item => item.Id == id);
}
