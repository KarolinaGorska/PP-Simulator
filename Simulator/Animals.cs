namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    private uint size = 3;
    public uint Size { get; set; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}