using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    /// <summary>
    /// </summary>
    public class SmallTorusMap : Map
    {
        /// <summary>
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// </summary>
        /// <param name="size">Rozmiar mapy. Musi być w zakresie od 5 do 20.</param>
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być pomiędzy 5 i 20.");
            Size = size;
        }

        /// <summary>
        /// </summary>
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        /// <summary>
        /// </summary>
        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            return new Point((nextPoint.X + Size) % Size, (nextPoint.Y + Size) % Size);
        }

        /// <summary>
        /// </summary>
        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonalPoint = p.NextDiagonal(d);
            return new Point((nextDiagonalPoint.X + Size) % Size, (nextDiagonalPoint.Y + Size) % Size);
        }
    }
}
