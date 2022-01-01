public class BoardState
{
    private BoardObject[,] matrix;

    public BoardState(int width, int height)
    {
        matrix = new BoardObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    matrix[x, y] = new WallBlock(x, y);
                else
                    matrix[x, y] = new EmptyTile(x, y);

                if (x == 4 && y == 4)
                {
                    matrix[x, y] = new RegularBlock(x, y);
                }
                if (x == 5 && y == 4)
                {
                    matrix[x, y] = new RegularBlock(x, y);
                }
                if (x == 1 && y == 3)
                {
                    matrix[x, y] = new RegularBlock(x, y);
                }
                if (x == 3 && y == 3)
                {
                    matrix[x, y] = new WallBlock(x, y);
                }
                if (x == 6 && y == 6)
                    matrix[x, y] = new WallBlock(x, y);
            }
        }
    }

    public BoardObject GetSquare(int x, int y)
    {
        return matrix[x, y];
    }

    public void SetSquare(int x, int y, BoardObject square)
    {
        matrix[x, y] = square;
        square.X = x;
        square.Y = y;
    }
}
