namespace Simulator.Maps;
    public interface IMappable
    {
        public char Symbol { get; }
        void Go(Direction direction);
        void SetMap(Map map, Point position);
    }
