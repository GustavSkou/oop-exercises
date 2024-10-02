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
        foreach (var item in sudokuBoard)
        {
            if (item == 0)
            {
                return false;
            }
        }

        bool CheckRows()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    for (int toCheck = col + 1; toCheck < columns; toCheck++)       //check rows
                    {
                        if (sudokuBoard[row, col] == sudokuBoard[row, toCheck])     //not valid
                        {
                            Console.WriteLine($"row {row} \ncolumn {col}");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool CheckColumns()
        {
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows - 1; row++)
                {
                    for (int toCheck = row + 1; toCheck < rows; toCheck++)        //check rows
                    {
                        if (sudokuBoard[row, col] == sudokuBoard[toCheck, col])     //not valid
                        {
                            Console.WriteLine($"row {row} \ncolumn {col}");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool CheckSquares()
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
    return CheckSquares() && CheckRows() && CheckColumns();
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

    public int[,] SolveSudoku()
    {
        SudokuCell[,] solutionSudokuBoard = new SudokuCell[9,9];
        int[] possibleNums;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (sudokuBoard[row, col] != 0) //plotting all not 0 value in
                {
                    solutionSudokuBoard[row, col] = new SudokuCell(row, col, sudokuBoard[row, col]);
                    continue;
                }
                else
                {
                    possibleNums = EliminateNums(row, col);
                }

                if (possibleNums.Length > 1)
                {
                    solutionSudokuBoard[row, col] = new SudokuCell(row, col, possibleNums);
                }

                solutionSudokuBoard[row, col] = new SudokuCell(row, col, possibleNums[0]);

            }
        }

        sudokuBoard = NormalizeBoard(solutionSudokuBoard);
        return sudokuBoard;
    }
    int[] EliminateNums(int cellRow, int cellCol)
    {
        HashSet<int> possibleNums = new HashSet<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};

        possibleNums = EliminateRow(possibleNums, cellRow);

        if (1 < possibleNums.Count)
        {
            possibleNums = EliminateCollumn(possibleNums, cellCol);
        }
        return possibleNums.ToArray();
    }

    HashSet<int> EliminateRow(HashSet<int> possibleNums, int cellRow)
    {
        for (int col = 0; col < columns; col++) // look though row
        {
            if (sudokuBoard[cellRow, col] != 0) 
            {
                possibleNums.Remove(sudokuBoard[cellRow, col]);
            }
        }
        return possibleNums;
    }

    HashSet<int> EliminateCollumn(HashSet<int> possibleNums, int cellCol)
    {
        for (int row = 0; row < rows; row++) // look though collumn
        {
            if (sudokuBoard[row, cellCol] != 0) 
            {
                possibleNums.Remove(sudokuBoard[row, cellCol]);
            }
        }
        return possibleNums;
    }

    HashSet<int> EliminateSquare(HashSet<int> possibleNums, int cellRow, int cellCol)
    {

        return possibleNums;
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