namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        //Add(Creature, Point)

        //Remove(Creature, Point)

        //Move()

        //At(Point) albo x,y
        private readonly Rectangle map;
        public int SizeX { get; }
        public int SizeY { get; }
        public Map(int sizeX, int sizeY) 
        {
            if (sizeX < 5 || sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Minimalne wymiary mapy to 5x5.");
            }
            SizeX = sizeX;
            SizeY = sizeY;
            map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        }
        public virtual bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y <SizeY;
        }
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
    }
}