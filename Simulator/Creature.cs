namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
       
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public abstract string Info { get; }
    public abstract int Power { get; }
    public abstract string Greeting();
    //out
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        // Map.Next()
        // Map.Next() == Position -> nie robimy ruchu
        // Map.Move

        var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    //out
    public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
}