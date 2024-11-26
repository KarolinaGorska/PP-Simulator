﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    //List<Creature>? [,]_fields;
    private readonly List<Creature>?[,] fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");

        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high");
        fields = new List<Creature>?[sizeX, sizeY];
    }
    protected override List<Creature>?[,] Fields => fields;
}
    
   

