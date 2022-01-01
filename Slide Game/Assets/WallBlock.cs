using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : BoardObject
{
    public WallBlock(int x, int y)
    {
        obj = (GameObject)Resources.Load("Black");
        X = x;
        Y = y;
    }

    public override Direction Move(Direction dir)
    {
        return Direction.NONE;
    }

    public override string ToString()
    {
        return "WallBlock";
    }
}
