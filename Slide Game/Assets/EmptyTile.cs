using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : BoardObject
{
    public EmptyTile(int x, int y)
    {
        obj = (GameObject) Resources.Load("White");
        X = x;
        Y = y;
    }

    public override Direction Move(Direction dir)
    {
        return Direction.NONE;
    }

    public override string ToString()
    {
        return "EmptyTile";
    }
}
