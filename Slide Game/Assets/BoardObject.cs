using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardObject
{
    [SerializeField] protected GameObject obj;
    public int X { get; set; }
    public int Y { get; set; }

    public GameObject GetObject()
    {
        return obj;
    }

    public abstract Direction Move(Direction dir);
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT,
    NONE
}