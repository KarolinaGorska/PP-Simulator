namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
       
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public abstract string Info { get; }
    public abstract int Power { get; }
    public abstract void SayHi();
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
}