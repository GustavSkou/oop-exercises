
using System.Drawing;

class Sudoku
{
    public int rows, columns;

    public Sudoku(int inputRows, int inputColumns)
    {
        rows = inputRows;
        columns = inputColumns;
    }

    public int[,] buildSudoku(int[,] sudokuNums)
    {
        int[,] sudokuBoard = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                sudokuBoard[row, col] = sudokuNums[row, col];
            }
        }

        return sudokuBoard;
    }

    public void printSudoku(int[,] someSudokuBoard)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(someSudokuBoard[row, col] + "  ");

                if (col == columns - 1)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int[,] someSudokuBoard = {
        { 3, 1, 6, 5, 7, 8, 4, 9, 2 },
        { 5, 2, 9, 1, 3, 4, 7, 6, 8 },
        { 4, 8, 7, 6, 2, 9, 5, 3, 1 },
        { 2, 6, 3, 0, 1, 5, 9, 8, 7 },
        { 9, 7, 4, 8, 6, 0, 1, 2, 5 },
        { 8, 5, 1, 7, 9, 2, 6, 4, 3 },
        { 1, 3, 8, 0, 4, 7, 2, 0, 6 },
        { 6, 9, 2, 3, 5, 1, 8, 7, 4 },
        { 7, 4, 5, 0, 8, 6, 3, 1, 0 }};


        Sudoku newSudoku = new Sudoku(9, 9 );

        newSudoku.printSudoku(newSudoku.buildSudoku(someSudokuBoard));
    }
}