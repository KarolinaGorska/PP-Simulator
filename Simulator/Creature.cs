namespace Simulator;

public class Creature
{
    private string name = "Unknown";

    public string Name
    {
        get => name;
        init
        {
            name = value.Trim();
            name = string.Join(" ", value.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            name = name.Substring(0, Math.Min(name.Length, 25));
            if (name.Length < 3)
            {
                name = name.PadRight(3, '#');
            }
            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
            }
        }
    }

    private int level = 1;
    public int Level
    {
        get { return level; }
        set
        {
            level = Math.Clamp(value, 1, 10);
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

    public string Info => $"{Name} [{level}]";

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}