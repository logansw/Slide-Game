using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBlock : BoardObject
{
    public RegularBlock(int x, int y)
    {
        obj = (GameObject)Resources.Load("Red");
        X = x;
        Y = y;
    }

    public override Direction Move(Direction dir)
    {
        return dir;
    }

    public override string ToString()
    {
        return "RegularBlock";
    }
}