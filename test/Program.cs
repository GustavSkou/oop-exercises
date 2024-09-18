using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Sudoku
{
    public int rows, columns;
    public bool isValid;
	public int[,] sudokuBoard, squares;
	
    public Sudoku(int inputRows, int inputColumns, int[,] someSudokuBoard)
    {
        rows = inputRows;
        columns = inputColumns;
		sudokuBoard = someSudokuBoard;
    }

    public bool checkSudoku()
    {
		bool isCellsValid, isRowsValid, isColumnsValid;                         // 1 2 3 //
		isCellsValid = false;                                                   // 4 5 6 //
		isRowsValid = false;                                                    // 7 8 9 //
		isColumnsValid = false;
		
        bool checkRows()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns-1; col++)
                {
                    for (int toCheck = col+1; toCheck < columns; toCheck++)				//check rows
                    {
                        if (sudokuBoard[row, col] == sudokuBoard[row, toCheck])			//not valid
                        {
                            Console.WriteLine(row + "" + col);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool checkColumns()
        {
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows-1; row++)
                {
                    for (int toCheck = row+1; toCheck < rows; toCheck++)				//check rows
                    {
                        if (sudokuBoard[row, col] == sudokuBoard[toCheck, col])			//not valid
                        {
                            Console.WriteLine(row + "" + col);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

// (0,0)(0,1)(0,2)
// (1,0)(1,1)(1,2)
// (2,0)(2,1)(2,2)

        bool checkSquares()
        {
            int x = 0;
            int y = 3;
            int [,] square = new int[9, 9];

            for(int n = 0; n < 3; n++)
            {
                x = n * 3;
                y = (n + 1) * 3;

                for (int row = x; row < y; row++)
                {
                    for (int col = x; col < y; col++)
                    {

                    }
                }
            }
            return true;
        }

        Console.WriteLine(checkColumns());
        Console.WriteLine(checkRows());
        Console.WriteLine(checkSquares());


        return isCellsValid && isRowsValid && isColumnsValid;
    }

    public void Print()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(sudokuBoard[row, col] + "  ");

                if (col == columns - 1)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}

// 1, 4, 2,
class Program
{
    static void Main()
    {
        int[,] someSudokuBoard = {
            {3, 1, 6, 5, 7, 8, 4, 9, 2}, 
            {5, 2, 9, 1, 3, 4, 7, 6, 8}, 
            {4, 8, 7, 6, 2, 9, 5, 3, 1}, 
            {2, 6, 3, 4, 1, 5, 9, 8, 7}, 
            {9, 7, 4, 8, 6, 3, 1, 2, 5},
            {8, 5, 1, 7, 9, 2, 6, 4, 3},
            {1, 3, 8, 9, 4, 7, 2, 5, 6},
            {6, 9, 2, 3, 5, 1, 8, 7, 4},
            {7, 4, 5, 2, 8, 6, 3, 1, 9}
            };

        Sudoku newSudoku = new Sudoku(9, 9, someSudokuBoard);

        newSudoku.Print();
		newSudoku.checkSudoku();
    }
}