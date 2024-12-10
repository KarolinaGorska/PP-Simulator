namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa za duża");
            }

            _fields = new Dictionary<Point, List<IMappable>>();
        }

        protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

        public override void Add(IMappable creature, Point position)
        {
            if (!_fields.ContainsKey(position))
            {
                _fields[position] = new List<IMappable>();
            }

            _fields[position].Add(creature);
        }

        public override void Remove(IMappable creature, Point position)
        {
            if (_fields.ContainsKey(position))
            {
                _fields[position].Remove(creature);
                if (_fields[position].Count == 0)
                {
                    _fields.Remove(position);
                }
            }
        }

        public override List<IMappable> At(Point position)
        {
            return _fields.ContainsKey(position) ? _fields[position] : new List<IMappable>();
        }

        public override Point Next(Point p, Direction d)
        {
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            return p;
        }

        public override void Move(IMappable creature, Point position, Direction direction)
        {
            var newPosition = Next(position, direction);
            Remove(creature, position);
            Add(creature, newPosition);
        }
    }
}
