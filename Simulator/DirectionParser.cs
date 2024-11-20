namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directionsList = new List<Direction>();

        foreach (char c in input.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directionsList.Add(Direction.Up);
                    break;
                case 'R':
                    directionsList.Add(Direction.Right);
                    break;
                case 'D':
                    directionsList.Add(Direction.Down);
                    break;
                case 'L':
                    directionsList.Add(Direction.Left);
                    break;
            }
        }

        return directionsList;
    }
}