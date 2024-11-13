namespace Simulator;
public class Orc : Creature
{
    private int huntCounter = 0;
    private int rage;
    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Name = name;
        Level = level;
        Rage = rage;
    }
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }
    public override int Power => Level * 7 + Rage * 3;
    public override string Info => $"{Name} [{Level}][{Rage}]";
    public override string Greeting()
    {
         return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }
    public void Hunt()
    {
        huntCounter++;
        if (huntCounter % 2 == 0)
        {
            rage++;
        }
    }
}