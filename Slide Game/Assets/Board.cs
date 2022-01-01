using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public BoardState boardState;
    public int Width { get; set; }
    public int Height { get; set; }

    public List<GameObject> drawnObjects;

    // Start is called before the first frame update
    void Start()
    {
        Width = 8;
        Height = 8;
        boardState = new BoardState(Width, Height);

        DrawBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawBoard()
    {
        for (int x = 0; x < Width; x++) {
            for (int y = 0; y < Height; y++)
            {
                drawnObjects.Add(Instantiate(boardState.GetSquare(x, y).GetObject(), new Vector2(x, y), Quaternion.identity));
            }
        }
    }

    public void ClearBoard()
    {
        foreach(GameObject obj in drawnObjects)
        {
            Destroy(obj);
        }
        drawnObjects.Clear();
    }
}
