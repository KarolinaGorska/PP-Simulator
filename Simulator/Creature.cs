using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public abstract char Symbol { get; }
    private string name = "Unknown";
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void InitMapAndPosition(Map map, Point position)
    {
        if (Map != null)
            throw new InvalidOperationException("Ten stwór jest już przypisane do mapy.");

        if (map == null)
            throw new ArgumentNullException("Mapa nie może być null.");

        if (!map.Exist(position))
            throw new ArgumentException("Ta pozycja nie jest prawidłowa na tej mapie.", nameof(position));


        Map = map;
        Position = position;

        map.Add(this, position);
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
        return $"{Symbol}: {GetType().Name.ToUpper()}";
    }
    public void Go(Direction direction)
    {

        if (Map == null) throw new InvalidOperationException("Creature cannot move since it's not on the map!");

        var newPosition = Map.Next(Position, direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }
}