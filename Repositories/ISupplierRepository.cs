namespace ConfectioneryFactory.Repositories;

public interface ISupplierRepository
{
    IReadOnlyList<Supplier> GetAll();

    Supplier? GetById(int id);

    void Add(Supplier item);

    void Update(Supplier item);

    void Delete(int id);
}
