namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint;

            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X, p.Y + 1);
                    if (nextPoint.Y >= SizeY)
                    {
                        nextPoint = new Point(p.X, p.Y - 1);
                    }
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X, p.Y - 1);
                    if (nextPoint.Y < 0)
                    {
                        nextPoint = new Point(p.X, p.Y + 1);
                    }
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y);
                    if (nextPoint.X < 0)
                    {
                        nextPoint = new Point(p.X + 1, p.Y);
                    }
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y);
                    if (nextPoint.X >= SizeX)
                    {
                        nextPoint = new Point(p.X - 1, p.Y);
                    }
                    break;
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }

            // Sprawdzamy, czy obiekt nadal wykracza poza mapę po odbiciu
            if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
            {
                return p;
            }

            return nextPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint;

            switch (d)
            {
                case Direction.Up:
                    nextPoint = new Point(p.X + 1, p.Y + 1);
                    if (nextPoint.X >= SizeX || nextPoint.Y >= SizeY)
                    {
                        nextPoint = new Point(p.X - 1, p.Y - 1);
                    }
                    break;
                case Direction.Down:
                    nextPoint = new Point(p.X - 1, p.Y - 1);
                    if (nextPoint.X < 0 || nextPoint.Y < 0)
                    {
                        nextPoint = new Point(p.X + 1, p.Y + 1);
                    }
                    break;
                case Direction.Left:
                    nextPoint = new Point(p.X - 1, p.Y + 1);
                    if (nextPoint.X < 0 || nextPoint.Y >= SizeY)
                    {
                        nextPoint = new Point(p.X + 1, p.Y - 1);
                    }
                    break;
                case Direction.Right:
                    nextPoint = new Point(p.X + 1, p.Y - 1);
                    if (nextPoint.X >= SizeX || nextPoint.Y < 0)
                    {
                        nextPoint = new Point(p.X - 1, p.Y + 1);
                    }
                    break;
                default:
                    throw new ArgumentException("Nieznany kierunek");
            }

            if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
            {
                return p;
            }

            return nextPoint;
        }
    }
}