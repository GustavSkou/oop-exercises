class Sudoku
{
    public int rows = 9, columns = 9;
	public int[,] sudokuBoard;
	
    public Sudoku(int[,] sudokuBoard)
    {
		this.sudokuBoard = sudokuBoard;
    }

    public bool IsSudokuSolved()
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
                            Console.WriteLine($"row {row} \ncolumn {col}");
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
                            Console.WriteLine($"row {row} \ncolumn {col}");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool checkSquares()
        {  
            for(int squareRow = 0; squareRow < 3; squareRow++) //move though the 3 rows of squares
            {
                for(int squareCol = 0; squareCol < 3; squareCol++) //move though the 3 columns of squares
                {

                    for(int row = 3 * squareRow; row < 3*(1+squareRow); row++)    //check single square
                    {
                        for(int col = 3 * squareCol; col < 3*(1+squareCol); col++)
                        {
                            
                            for (int rowToCheck = 3 * squareRow; rowToCheck < 3*(1+squareRow); rowToCheck++)
                            {
                                for(int colToCheck = 3 * squareCol; colToCheck < 3*(1+squareCol); colToCheck++) 
                                {
                                    if (sudokuBoard[row, col] == sudokuBoard[rowToCheck, colToCheck] && (row != rowToCheck && columns != colToCheck))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        return checkSquares() && checkRows() && checkColumns();
    }

    public void Print()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(sudokuBoard[row, col] + "  ");

                if (col == 8)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}