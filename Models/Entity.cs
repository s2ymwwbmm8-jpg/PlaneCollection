namespace ConfectioneryFactory.Models;

public abstract class Entity
{
    public int Id { get; private set; }

    public void AssignId(int id)
    {
        if (Id != 0)
        {
            throw new InvalidOperationException("Id has already been assigned.");
        }

        Id = id;
    }
}
