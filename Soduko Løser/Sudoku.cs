class Sudoku
{
    public int rows = 9, columns = 9;
    public SudokuCell[,] sudokuBoard = new SudokuCell[9,9];
    public int[,][] squares = new int[3,3][];
    public Sudoku(int[,] someSudokuBoard)
    {
        squares[0,0] = new int[9];
        squares[0,1] = new int[9];
        squares[0,2] = new int[9];
        squares[1,0] = new int[9];
        squares[1,1] = new int[9];
        squares[1,2] = new int[9];
        squares[2,0] = new int[9];
        squares[2,1] = new int[9];
        squares[2,2] = new int[9];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                this.sudokuBoard[row, col] = new SudokuCell(row, col, someSudokuBoard[row, col]);  
            }
        }
        
        for (int squareRow = 0; squareRow < 3; squareRow++)
        {
            for (int squareCol = 0; squareCol < 3; squareCol++)
            {
                int i = 0;
                for (int row = 3 * squareRow; row < 3 * (1 + squareRow); row++) 
                {
                    for (int col = 3 * squareCol; col < 3 * (1 + squareCol); col++)
                    {
                        squares[squareRow,squareCol][i] = sudokuBoard[row, col].value;
                        i++;
                    }
                }
            }
        }
    }

    public bool IsSudokuSolved()
    { 
        return IsBoardFilled() && CheckSquares() && CheckRows() && CheckColumns();
    }
    protected bool IsBoardFilled()
    {
        foreach (SudokuCell cell in sudokuBoard)
        {
            if (cell.value == 0)
            {
                return false;
            }
        }
        return true;
    }
    protected bool CheckRows()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns - 1; col++)
            {
                for (int toCheck = col + 1; toCheck < columns; toCheck++)       //check rows
                {
                    if (sudokuBoard[row, col].value == sudokuBoard[row, toCheck].value)     //not valid
                    {
                        Console.WriteLine($"row {row} \ncolumn {col}");
                        return false;
                    }
                }
            }
        }
        return true;
    }
    protected bool CheckColumns()
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int toCheck = row + 1; toCheck < rows; toCheck++)        //check rows
                {
                    if (sudokuBoard[row, col].value == sudokuBoard[toCheck, col].value)     //not valid
                    {
                        Console.WriteLine($"row {row} \ncolumn {col}");
                        return false;
                    }
                }
            }
        }
        return true;
    }
    protected bool CheckSquares()
    {
        for (int squareRow = 0; squareRow < 3; squareRow++) //move though the 3 rows of squares
        {
            for (int squareCol = 0; squareCol < 3; squareCol++) //move though the 3 columns of squares
            {
                for (int row = 3 * squareRow; row < 3 * (1 + squareRow); row++)    //check single square
                {
                    for (int col = 3 * squareCol; col < 3 * (1 + squareCol); col++)
                    {
                        for (int rowToCheck = 3 * squareRow; rowToCheck < 3 * (1 + squareRow); rowToCheck++)
                        {
                            for (int colToCheck = 3 * squareCol; colToCheck < 3 * (1 + squareCol); colToCheck++)
                            {
                                if (sudokuBoard[row, col].value == sudokuBoard[rowToCheck, colToCheck].value && (row != rowToCheck && columns != colToCheck))
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
    public void Print()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write(sudokuBoard[row, col].value + "  ");
                if (col == 8)
                {
                    Console.Write("\n");
                }
            }
        }
    }

    public int[,] SolveSudoku()
    {
        int[] possibleValues;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (sudokuBoard[row, col].value == 0) // If the cell does not contain a value.
                {
                    possibleValues = EliminateValues(row, col);

                    if (possibleValues.Length > 1) // If there is more than 1 possiable values for a cell then all the values are saved
                    {
                        sudokuBoard[row, col].possibleValues = possibleValues;
                    }
                    else    // We know there is only one possiable value, and the cell value is set 
                    {
                        sudokuBoard[row, col].value = possibleValues[0];
                        return SolveSudoku();   //Go back to the start then a new value is set
                    }
                }
            }
        }
        
        /*if (!IsBoardFilled())
        {
            Print();
            Console.WriteLine("");
            return SolveSudoku();
        }*/

        return NormalizeBoard(sudokuBoard);
    }
    int[] EliminateValues(int cellRow, int cellCol)
    {
        HashSet<int> possibleValues = new HashSet<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};

        possibleValues = EliminateRow(possibleValues, cellRow);
        if (1 < possibleValues.Count)
        {
            possibleValues = EliminateCollumn(possibleValues, cellCol);
        }
        if (1 < possibleValues.Count)
        {
            possibleValues = EliminateSquare(possibleValues, cellRow, cellCol);
        }

        return possibleValues.ToArray();
    }

    HashSet<int> EliminateRow(HashSet<int> possibleValues, int cellRow)
    {
        for (int col = 0; col < columns; col++) // look though row
        {
            if (sudokuBoard[cellRow, col].value != 0) 
            {
                possibleValues.Remove(sudokuBoard[cellRow, col].value);
            }
        }
        return possibleValues;
    }

    HashSet<int> EliminateCollumn(HashSet<int> possibleValues, int cellCol)
    {
        for (int row = 0; row < rows; row++) // look though collumn
        {
            if (sudokuBoard[row, cellCol].value != 0) 
            {
                possibleValues.Remove(sudokuBoard[row, cellCol].value);
            }
        }
        return possibleValues;
    }

    HashSet<int> EliminateSquare(HashSet<int> possibleValues, int cellRow, int cellCol)
    {
        int squareRow = cellRow / 3;
        int squareCol = cellCol / 3;

        for(int index = 0; index < squares[squareRow,squareCol].Length; index++)
        {
            if (squares[squareRow,squareCol][index] != 0)
            {
                possibleValues.Remove(squares[squareRow,squareCol][index]);
            }
        }
        return possibleValues;
    }

    int[,] NormalizeBoard(SudokuCell[,] sudokuBoard)
    {
        int[,] normalizedBoard = new int[9,9];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                normalizedBoard[row,col] = sudokuBoard[row, col].value;
            }
        }
        return normalizedBoard;
    }
}