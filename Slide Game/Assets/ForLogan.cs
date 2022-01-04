using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; // Need this

// I don't know where this code should go, but it scans through all tiles in the level editor
// and gives info about which tile was found where.

public class ForLogan : MonoBehaviour
{
    private GridLayout grid; // Need these
    private Tilemap tilemap;

    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<GridLayout>();
        tilemap = grid.GetComponentInChildren<Tilemap>();
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        // bounds.size.x // (width)
        // bounds.size.y // (height)
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            // use tile.name
            // use Vector3Int coordinate = position - bounds.position; To get nice coordinates starting from (0,0), the bottomleft-most tile
        }
    }
}
