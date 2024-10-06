using System.Collections;
using System.Runtime.Serialization;

class Sudoku
{
    public int rows = 9, columns = 9;
    public SudokuCell[,] sudokuBoard = new SudokuCell[9,9];
    public List <SudokuCell[,]> backTrackingBoards = new List <SudokuCell[,]>();
    public int[,][] squares = new int[3,3][];
    public bool isBackTracking = false;
    public Sudoku(int[,] someSudokuBoard)
    {
        sudokuBoard = copySudokuIntoBoard(someSudokuBoard);
        FillSquares(sudokuBoard);
    }
    SudokuCell[,] copySudokuIntoBoard(int[,] someSudokuBoard)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                sudokuBoard[row, col] = new SudokuCell(row, col, someSudokuBoard[row, col]);  
            }
        }
        return sudokuBoard;
    }
    void FillSquares(SudokuCell[,] sudokuBoard)
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
    public bool IsSudokuSolved(SudokuCell[,] sudokuBoard)
    { 
        return CheckSquares(sudokuBoard) && CheckRows(sudokuBoard) && CheckColumns(sudokuBoard);
    }
    protected bool IsBoardFilled(SudokuCell[,] sudokuBoard)
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
    protected bool CheckRows(SudokuCell[,] sudokuBoard)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns - 1; col++)
            {
                if (sudokuBoard[row,col].value == 0)
                {
                    continue;
                }

                for (int toCheck = col + 1; toCheck < columns; toCheck++)       //check rows
                {
                    if (sudokuBoard[row, col].value == sudokuBoard[row, toCheck].value)     //not valid
                    {
                        Console.WriteLine($"Column mistake \nrow:{row}, column:{col}\nrow:{row}, column:{toCheck}");
                        return false;
                    }
                }
            }
        }
        return true;
    }
    protected bool CheckColumns(SudokuCell[,] sudokuBoard)
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (sudokuBoard[row,col].value == 0)
                {
                    continue;
                }

                for (int toCheck = row + 1; toCheck < rows; toCheck++)        //check rows
                {
                    if (sudokuBoard[row, col].value == sudokuBoard[toCheck, col].value)     //not valid
                    {
                        Console.WriteLine($"Column mistake \nrow:{row}, column:{col}\nrow:{toCheck}, column:{col}");
                        return false;
                    }
                }
            }
        }
        return true;
    }
    protected bool CheckSquares(SudokuCell[,] sudokuBoard)
    {
        for (int squareRow = 0; squareRow < 3; squareRow++) //move though the 3 rows of squares
        {
            for (int squareCol = 0; squareCol < 3; squareCol++) //move though the 3 columns of squares
            {
                for (int row = 3 * squareRow; row < 3 * (1 + squareRow); row++)    //check single square
                {
                    for (int col = 3 * squareCol; col < 3 * (1 + squareCol); col++)
                    {
                        if (sudokuBoard[row,col].value == 0)
                        {
                            continue;
                        }

                        for (int rowToCheck = 3 * squareRow; rowToCheck < 3 * (1 + squareRow); rowToCheck++)
                        {
                            for (int colToCheck = 3 * squareCol; colToCheck < 3 * (1 + squareCol); colToCheck++)
                            {
                                if (sudokuBoard[row, col].value == sudokuBoard[rowToCheck, colToCheck].value && (row != rowToCheck && columns != colToCheck))
                                {
                                    Console.WriteLine($"Square mistake\nrow:{row},column{col}\nrow:{rowToCheck}, column:{colToCheck}");
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
        Console.WriteLine("");
    }
    public void Print(SudokuCell[,] sudokuBoard)
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
        Console.WriteLine("");
    }

/*
1. løst alt der logisk kan løses i første omgang
2. gem boardets nuværene tilstand 
3. gæt på en værdi til den først cell på boarded, 
4. løst alt der logisk kan løses i første omgang,
5. gem boardets nuværene tilstand
6. gæt på en værdi til den først cell på boarded,
7. løst alt der logisk kan løses i første omgang,

*/
    public int[,] Solve()
    {
        StartEliminateLogik(sudokuBoard);

        if(!IsSudokuSolved(sudokuBoard) || !IsBoardFilled(sudokuBoard))
        {
            StartBackTracking(sudokuBoard);
        }

        return NormalizeBoard(sudokuBoard);
    }

    public void StartEliminateLogik(SudokuCell[,] sudokuBoard)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (sudokuBoard[row, col].value == 0) // If the cell does not contain a value.
                {
                    ArrayList possibleValues = EliminateValues(sudokuBoard, row, col);

                    if (possibleValues.Count > 1) // If there is more than 1 possiable values for a cell then all the values are saved
                    {
                        sudokuBoard[row, col].possibleValues = possibleValues;
                    }
                    else    // We know there is only one possiable value, and the cell value is set 
                    {
                        sudokuBoard[row, col].value = (int) possibleValues[0];
                        FillSquares(sudokuBoard);
                        StartEliminateLogik(sudokuBoard);   //Go back to the start then a new value is set
                    }
                }
            }
        }
    }
    SudokuCell[,] StartBackTracking(SudokuCell[,] sudokuBoard)
    {   
        SudokuCell[,] backtrackingBoard = sudokuBoard;
        backTrackingBoards.Add(backtrackingBoard);
        int end = backTrackingBoards.Count - 1;
        var curruntBoard = backTrackingBoards[end];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (curruntBoard[row, col].value == 0)                                               // If the first cell with no value
                {
                    curruntBoard[row, col].value = (int) sudokuBoard[row, col].possibleValues[0];    // give it, its first possiable value
                    curruntBoard[row, col].possibleValues.RemoveAt(0);

                    StartEliminateLogik(curruntBoard);                                                 //try to solve again
                
                    Print(curruntBoard);
                    Console.WriteLine(backTrackingBoards.Count());

                    if (!IsSudokuSolved(curruntBoard))
                    {
                        backTrackingBoards.RemoveAt(backTrackingBoards.Count-1);
                        StartBackTracking(curruntBoard);
                    }

                    if (!IsBoardFilled(curruntBoard))
                    {
                        StartBackTracking(curruntBoard);
                    }
                }
            }
        }

        return backTrackingBoards[0];
    }

    ArrayList EliminateValues(SudokuCell[,] sudokuBoard, int cellRow, int cellCol)
    {
        HashSet<int> possibleValues = new HashSet<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        
        possibleValues = EliminateRow(sudokuBoard, possibleValues, cellRow);
        if (1 < possibleValues.Count)
        {
            possibleValues = EliminateCollumn(sudokuBoard, possibleValues, cellCol);
        }
        if (1 < possibleValues.Count)
        {
            possibleValues = EliminateSquare(sudokuBoard, possibleValues, cellRow, cellCol);
        }
        ArrayList result = new ArrayList (possibleValues.ToArray());
        return result;
    }

    HashSet<int> EliminateRow(SudokuCell[,] sudokuBoard, HashSet<int> possibleValues, int cellRow)
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

    HashSet<int> EliminateCollumn(SudokuCell[,] sudokuBoard, HashSet<int> possibleValues, int cellCol)
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

    HashSet<int> EliminateSquare(SudokuCell[,] sudokuBoard, HashSet<int> possibleValues, int cellRow, int cellCol)
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