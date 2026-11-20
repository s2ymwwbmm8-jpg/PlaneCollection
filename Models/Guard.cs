namespace ConfectioneryFactory.Models;

internal static class Guard
{
    public static string NotEmpty(string? value, string fieldName)
    {
        ArgumentNullException.ThrowIfNull(value, fieldName);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException($"{fieldName} must not be empty.");
        }

        return value.Trim();
    }

    public static decimal Positive(decimal value, string fieldName)
    {
        if (value <= 0)
        {
            throw new ValidationException($"{fieldName} must be greater than zero.");
        }

        return value;
    }
}
