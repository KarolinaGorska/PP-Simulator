namespace Simulator.Maps;

public interface IMappable
{
    object Info { get; set; }
    object Position { get; set; }

    void Go(Direction direction);
    void SetMap(Map map, Point position);
}
