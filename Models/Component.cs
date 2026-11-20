namespace ConfectioneryFactory.Models;

public class Component : Entity
{
    public string Name { get; private set; } = string.Empty;

    public UnitOfMeasure Unit { get; private set; }

    private Component()
    {
    }

    public static Component Create(string name, UnitOfMeasure unit)
    {
        var component = new Component();
        component.Update(name, unit);
        return component;
    }

    public void Update(string name, UnitOfMeasure unit)
    {
        var validName = Guard.NotEmpty(name, "Name");

        if (!Enum.IsDefined(unit))
        {
            throw new ValidationException("Unit is not valid.");
        }

        Name = validName;
        Unit = unit;
    }
}
