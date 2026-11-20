namespace ConfectioneryFactory.Enums;

[Flags]
public enum Allergens
{
    None = 0,
    Nuts = 1,
    Milk = 2,
    Gluten = 4,
    Soy = 8
}
