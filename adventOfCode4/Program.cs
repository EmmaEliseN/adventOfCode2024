

class Program
{

    static void Main()
    {
        string path = "input.txt";
        string[] input = File.ReadAllLines(path);

        char[,] matrix = CreateMatrix(input);

        var res = CountXmas(matrix);
        var res2 = CountXmas2(matrix);
        Console.WriteLine("-------------");
        Console.WriteLine(res);
        Console.WriteLine("-------------");
        Console.WriteLine(res2);

    }

    static char[,] CreateMatrix(string[] input)
    {
        int rows = input[0].Length;
        int cols = input.Length;
        char[,] matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = input[i][j];
            }
        }

        return matrix;
    }

    static int CountXmas(char[,] matrix)
    {
        var res = 0;
        int imax = matrix.GetLength(0) - 3;
        int jmax = matrix.GetLength(1) - 3;

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'X')
                {
                    if (j >= 3 && CheckDirection(Direction.Left, matrix, i, j, 1))
                        res++;
                    if (j < jmax && CheckDirection(Direction.Right, matrix, i, j, 1))
                        res++;
                    if (i >= 3 && CheckDirection(Direction.Up, matrix, i, j, 1))
                        res++;
                    if (i < imax && CheckDirection(Direction.Down, matrix, i, j, 1))
                        res++;
                    if (i >= 3 && j < matrix.GetLength(1) - 3 && CheckDirection(Direction.UpRight, matrix, i, j, 1))
                        res++;
                    if (i >= 3 && j >= 3 && CheckDirection(Direction.UpLeft, matrix, i, j, 1))
                        res++;
                    if (i < imax && j < jmax && CheckDirection(Direction.DownRight, matrix, i, j, 1))
                        res++;
                    if (i < imax && j >= 3 && CheckDirection(Direction.DownLeft, matrix, i, j, 1))
                        res++;
                }
            }
        }

        return res;
    }

    public enum Direction
    {
        Right = 0,
        Left = 1,
        Up = 2,
        Down = 3,
        UpRight = 4,
        UpLeft = 5,
        DownRight = 6,
        DownLeft = 7
    }

    static int[] GetMovement(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                return new int[] { 0, 1 };
            case Direction.Left:
                return new int[] { 0, -1 };
            case Direction.Up:
                return new int[] { -1, 0 };
            case Direction.Down:
                return new int[] { 1, 0 };
            case Direction.UpRight:
                return new int[] { -1, 1 };
            case Direction.UpLeft:
                return new int[] { -1, -1 };
            case Direction.DownRight:
                return new int[] { 1, 1 };
            case Direction.DownLeft:
                return new int[] { 1, -1 };
            default:
                return new int[] { 0, 0 };
        }
    }

    static bool CheckDirection(Direction direction, char[,] matrix, int i, int j, int pos)
    {
        string xmas = "XMAS";
        var movement = GetMovement(direction);

        if (matrix[i + movement[0], j + movement[1]] == xmas[pos])
        {
            if (pos == 3)
            {
                return true;
            }
            else return CheckDirection(direction, matrix, i + movement[0], j + movement[1], pos + 1);
        }
        else
        {
            return false;
        }

    }

    static int CountXmas2(char[,] matrix)
    {
        var iMax = matrix.GetLength(0) - 1;
        var jMax = matrix.GetLength(1) - 1;
        var ret = 0;

        for (var i = 1; i <= iMax - 1; i++)
        {
            for (var j = 1; j <= jMax - 1; j++)
            {
                if (matrix[i, j] == 'A')
                {
                    if ((matrix[i - 1, j - 1] == 'M' && matrix[i + 1, j - 1] == 'M' && matrix[i + 1, j + 1] == 'S' && matrix[i - 1, j + 1] == 'S') ||
                        (matrix[i - 1, j - 1] == 'S' && matrix[i + 1, j - 1] == 'S' && matrix[i + 1, j + 1] == 'M' && matrix[i - 1, j + 1] == 'M') ||
                        (matrix[i - 1, j - 1] == 'M' && matrix[i + 1, j - 1] == 'S' && matrix[i + 1, j + 1] == 'S' && matrix[i - 1, j + 1] == 'M') ||
                        (matrix[i - 1, j - 1] == 'S' && matrix[i + 1, j - 1] == 'M' && matrix[i + 1, j + 1] == 'M' && matrix[i - 1, j + 1] == 'S'))
                    {
                        ret++;
                    }
                }
            }
        }

        return ret;
    }


}




