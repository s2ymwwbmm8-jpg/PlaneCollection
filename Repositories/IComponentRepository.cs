namespace ConfectioneryFactory.Repositories;

public interface IComponentRepository
{
    IReadOnlyList<Component> GetAll();

    Component? GetById(int id);

    void Add(Component item);

    void Update(Component item);

    void Delete(int id);
}
