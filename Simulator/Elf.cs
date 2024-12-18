﻿namespace Simulator;

public class Elf : Creature
{
    private int singCounter = 0;
    private int agility;
    public Elf()
    {
    }
    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    public override int Power => Level * 8 + Agility * 2;
    public override char Symbol => 'E';
    public override string Info => $"{Name} [{Level}][{Agility}]";
    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    }
    public void Sing()
    {
        singCounter++;
        if (singCounter % 3 == 0)
        {
            agility++;
        }
    }
}