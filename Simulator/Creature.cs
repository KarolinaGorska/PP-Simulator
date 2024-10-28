namespace Simulator;

public class Creature
{
    public string? Name { get; }

    private int level;

    public int Level
    {
        get => level;
        set => level = value > 0 ? value : 1;
    }

    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
       
    }

    public string Info => $"{Name} [{level}]";

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}