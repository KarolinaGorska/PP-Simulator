﻿namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';
    public Birds(string description = "Unknown Bird", int size = 3, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }
    public override string Info => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";
    protected override Point GetNewPosition(Direction direction) => CanFly
        ? Map.Next(Map.Next(Position, direction), direction)
        : Map.NextDiagonal(Position, direction);
}
