using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; set; }
    public virtual char Symbol => 'A';

    public virtual void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("This animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentException("Non-existing position for this map.");
        Map = map;
        Position = point;
        map.Add(this, point);
    }
    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Animal cannot move since it's not on the map!");
        var newPosition = GetNewPosition(direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }
    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }

    private string description = "Unknown";

    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public int Size { get; set; } = 3;
    public override string ToString()
    {
        return $"{Symbol}: {GetType().Name.ToUpper()}";
    }
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}