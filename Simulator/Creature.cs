using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public abstract char Symbol { get; }
    private string name = "Unknown";
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void SetMap(Map map, Point position)
    {

        Map = map;
        Position = position;
    }

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
    public abstract string Greeting();
    //out
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void Go(Direction direction)
    {
        if (Map == null)
        {
            Console.WriteLine("Creature's map is not set. Cannot move.");
            return;
        }
        Point nextPosition = Map.Next(Position, direction);
        if (!Map.Exist(nextPosition))
        {
            Console.WriteLine($"Invalid move. {this.Info} tried to move out of bounds.");
            return;
        }
        try
        {
            Map.Move(this, Position, direction);
            Position = nextPosition;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to move {this.Info}: {ex.Message}");
        }
    }
}