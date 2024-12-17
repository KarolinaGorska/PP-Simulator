namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; }
    char Symbol { get; }
    public string ToString();

    void Go(Direction direction);
    void SetMap(Map map, Point position);
}
