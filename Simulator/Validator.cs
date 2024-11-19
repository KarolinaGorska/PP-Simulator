namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();
        if (value.Length > max)
        {
            value = value.Substring(0, max).Trim();
        }
        if (value.Length < min)
        {
            int missingchars = min - value.Length;
            string padding = String.Concat(Enumerable.Repeat(placeholder, missingchars));
            value = $"{value}{padding}";
        }
        if (char.IsLower(value[0]))
        {
            value = (char.ToUpper(value[0]) + value.Substring(1));
        }
        return value;
    }
}
