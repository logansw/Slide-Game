using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] public Board board;
    private BoardState currentState;

    public void Start()
    {
        currentState = board.boardState;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("up");
            Tilt(Direction.UP);
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            Tilt(Direction.LEFT);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            Tilt(Direction.DOWN);
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Tilt(Direction.RIGHT);
        }
    }

    public void Tilt(Direction dir)
    {
        if (currentState == null)
        {
            currentState = board.boardState;
        }

        bool complete = false;
        while (!complete)
        {
            complete = true;
            // For each tile on the board, ask where it wants to move and decide if it's legal.
            // If legal, update the board state.
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    Debug.Log(currentState.GetSquare(x, y).ToString());
                    BoardObject currentSquare = currentState.GetSquare(x, y);
                    Direction intendedDirection = currentSquare.Move(dir);
                    switch (intendedDirection)
                    {
                        case Direction.NONE:
                            break;
                        case Direction.RIGHT:
                            if (TileEmpty(x+1, y))
                            {
                                complete = false;
                                currentState.SetSquare(x+1, y, currentSquare);
                                currentState.SetSquare(x, y, new EmptyTile(x, y));
                            }
                            break;
                        case Direction.LEFT:
                            if (TileEmpty(x-1, y))
                            {
                                complete = false;
                                currentState.SetSquare(x-1, y, currentSquare);
                                currentState.SetSquare(x, y, new EmptyTile(x, y));
                            }
                            break;
                        case Direction.UP:
                            if (TileEmpty(x, y+1))
                            {
                                complete = false;
                                currentState.SetSquare(x, y+1, currentSquare);
                                currentState.SetSquare(x, y, new EmptyTile(x, y));
                            }
                            break;
                        case Direction.DOWN:
                            if (TileEmpty(x, y-1))
                            {
                                complete = false;
                                currentState.SetSquare(x, y-1, currentSquare);
                                currentState.SetSquare(x, y, new EmptyTile(x, y));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        board.ClearBoard();
        board.DrawBoard();
    }

    private bool TileEmpty(int x, int y)
    {
        return (currentState.GetSquare(x, y) is EmptyTile);
    }
}
