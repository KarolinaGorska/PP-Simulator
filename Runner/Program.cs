using Simulator.Maps;
namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
    }

    static void Lab5a()
    {
        try
        {
            Rectangle rect1 = new Rectangle(2, 3, 8, 6);
            Console.WriteLine("Utworzono prostokąt ze współrzędnych: " + rect1);

            Point p1 = new Point(8, 6);
            Point p2 = new Point(2, 3);
            Rectangle rect2 = new Rectangle(p1, p2);
            Console.WriteLine("Utworzono prostokąt z punktów: " + rect2);

            try
            {
                Rectangle invalidRect = new Rectangle(5, 5, 5, 10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Oczekiwany wyjątek: " + ex.Message);
            }

            Point pointInside = new Point(4, 4);
            Point pointOutside = new Point(10, 10);

            Console.WriteLine($"Czy prostokąt {rect1} zawiera punkt {pointInside}? {rect1.Contains(pointInside)}");
            Console.WriteLine($"Czy prostokąt {rect1} zawiera punkt {pointOutside}? {rect1.Contains(pointOutside)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
    static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(10);
            Console.WriteLine("Mapa utworzona z rozmiarem: " + map.Size);

            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Oczekiwany wyjątek: " + ex.Message);
            }

            Point insidePoint = new Point(5, 5);
            Console.WriteLine($"Czy punkt {insidePoint} należy do mapy? {map.Exist(insidePoint)}");

            Point outsidePoint = new Point(15, 15);
            Console.WriteLine($"Czy punkt {outsidePoint} należy do mapy? {map.Exist(outsidePoint)}");

            Point nextPoint = map.Next(insidePoint, Direction.Up);
            Console.WriteLine($"Następny punkt po ruchu w górę od {insidePoint}: {nextPoint}");

            Point borderPoint = new Point(0, map.Size - 1);
            Point nextOutOfBounds = map.Next(borderPoint, Direction.Up);
            Console.WriteLine($"Następny punkt po ruchu w górę od {borderPoint} (poza mapę): {nextOutOfBounds}");

            Point nextDiagonalPoint = map.NextDiagonal(insidePoint, Direction.Right);
            Console.WriteLine($"Następny punkt po ruchu po skosie (prawo-dół) od {insidePoint}: {nextDiagonalPoint}");

            Point diagonalOutOfBounds = map.NextDiagonal(borderPoint, Direction.Right);
            Console.WriteLine($"Następny punkt po ruchu po skosie od {borderPoint} (poza mapę): {diagonalOutOfBounds}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
