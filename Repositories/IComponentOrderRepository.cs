namespace ConfectioneryFactory.Repositories;

public interface IComponentOrderRepository
{
    IReadOnlyList<ComponentOrder> GetAll();

    void Add(ComponentOrder item);
}
