using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Starting Simulator!\n");
            Console.WriteLine("Starting positions");

            BigBounceMap bounceMap = new(8, 6);

            List<IMappable> creatures = new()
            {
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals("Kroliki", 5),
                new Birds("Orly", 11, true),
                new Birds("Strusie", 4, false)
            };

            List<Point> points = new()
            {
                new Point(0, 0),
                new Point(7, 0),
                new Point(0, 5),
                new Point(7, 5),
                new Point(3, 3),
            };
            string moves = "dlurdruldlurdruldrul";

            try
            {
                var simulation = new Simulation(bounceMap, creatures, points, moves);
                var mapVisualizer = new MapVisualizer(bounceMap);
                Console.WriteLine("SIMULATION!");
                Console.WriteLine("\n---Starting Positions---");
                Console.WriteLine("Initial layout of the map with creatures:");
                mapVisualizer.Draw();

                var simulationHistory = new SimulationHistory(simulation);

                while (!simulation.Finished)
                {
                    Console.WriteLine("SIMULATION!");
                    Console.WriteLine($"Turn {simulation._currentMoveIndex + 1}");

                    simulation.Turn();
                    mapVisualizer.Draw();
                }

                Console.WriteLine("Simulation finished!");
                Console.WriteLine("\n---Simulation History---");

                int[] turnsToShow = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22 };
                var logVisualizer = new LogVisualizer(simulationHistory);

                foreach (var turn in turnsToShow)
                {
                    if (turn - 1 < simulationHistory.TurnLogs.Count)
                    {
                        Console.WriteLine($"\nTurn {turn}:");
                        logVisualizer.Draw(turn - 1);
                    }
                    else
                    {
                        Console.WriteLine($"\nTurn {turn}: Not available (simulation finished earlier)");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}