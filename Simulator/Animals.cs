namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    public required string Description
    {
        get => description;
        init
        {
            description = value.Trim().Substring(0, Math.Min(value.Trim().Length, 15));

            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }
            if (char.IsLower(description[0]))
            {
                description = char.ToUpper(description[0]) + description.Substring(1);
            }
        }
    }
    private uint size = 3;
    public uint Size { get; set; }

    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}