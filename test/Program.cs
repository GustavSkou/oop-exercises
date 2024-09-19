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
        bool checkSquares()
        {
            int[] squareList = new int[9];
  
            for(int square = 0; square < 3; square++)
            {
                int row = 3*square;
                int col = 3*square;
                squareList[0] = sudokuBoard[row+0, col+0]; 
                squareList[1] = sudokuBoard[row+0, col+1]; 
                squareList[2] = sudokuBoard[row+0, col+2];
                squareList[3] = sudokuBoard[row+1, col+0]; 
                squareList[4] = sudokuBoard[row+1, col+1]; 
                squareList[5] = sudokuBoard[row+1, col+2];
                squareList[6] = sudokuBoard[row+2, col+0]; 
                squareList[7] = sudokuBoard[row+2, col+1]; 
                squareList[8] = sudokuBoard[row+2, col+2];

                for (int i = 0; i < squareList.Length-1; i++)
                {
                    for (int n = i+1; n < squareList.Length; n++)
                    {
                        if(squareList[i]==squareList[n])
                        {
                            Console.Write(i + " " + n);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        return checkRows() && checkColumns() && checkSquares();
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

class Program
{
    static void Main()
    {
        int[,] someSudokuBoard = 
        {
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
		Console.WriteLine(newSudoku.checkSudoku());
    }
}