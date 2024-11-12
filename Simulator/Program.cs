namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
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
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        }
}
