using System.Drawing;
namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public int SizeX { get; }
        public int SizeY { get; }
        private Rectangle bounds;
        protected abstract List<IMappable>?[,] Fields { get; }
        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa za mała");
            }
            SizeX = sizeX;
            SizeY = sizeY;
            bounds = new Rectangle(0, 0, this.SizeX - 1, SizeY - 1);
        }
        /// 
        public virtual bool Exist(Point p)
        {
            return bounds.Contains(p);
        }

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
        public void Add(IMappable mappable, Point position)
        {

            int x = position.X;
            int y = position.Y;
            if (Fields[x, y] == null)
            {
                Fields[x, y] = new List<IMappable>();
            }
            Fields[x, y]!.Add(mappable);
        }
        public void Remove(IMappable mappable, Point position)
        {
            int x = position.X;
            int y = position.Y;
            var mappables = Fields[x, y];
            if (mappables != null)
            {
                mappables.RemoveAll(c => c == mappable);
                if (mappables.Count == 0)
                {
                    Fields[x, y] = null;
                }
            }
        }
        public void Move(IMappable mappable, Point position, Direction direction)
        {
            int x = position.X;
            int y = position.Y;
            Remove(mappable, position);

            var newPosition = Next(position, direction);

            Add(mappable, newPosition);
        }
        public List<IMappable> At(Point position)
        {
            int x = position.X;
            int y = position.Y;
            var mappablesAtPoint = new List<IMappable>();
            var mappables = Fields[x, y];
            if (mappables != null)
            {
                mappablesAtPoint.AddRange(mappables);
            }
            return mappablesAtPoint;
        }
    }
}
//Add(IMappable, Point)

//Remove(IMappable, Point)

//Move()

//At(Point) albo x,y