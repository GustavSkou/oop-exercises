using System.Drawing;

class Sudoku
{
    public int rows, columns;
    public bool isValid;
	public int[,] sudokuBoard;
	
    public Sudoku(int inputRows, int inputColumns, int[,] someSudokuBoard)
    {
        rows = inputRows;
        columns = inputColumns;
		sudokuBoard = someSudokuBoard;
		
    }

    /*public int[,] buildSudoku(int[,] sudokuNums)
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
    }*/
    public bool checkSudoku()
    {
		bool isCellsValid, isRowsValid, isColumnsValid;
		isCellsValid = false; 
		isRowsValid = false;
		isColumnsValid = false;
		
		for (int row = 0; row < rows; row++)
        {
			
			
            for (int col = 0; col < columns-1; col++)
            {
                for (int toCheck = col+1; toCheck < columns; toCheck++)				//check rows
				{
					if (sudokuBoard[row, col] == sudokuBoard[row, toCheck])			//not valid
					{
						isRowsValid = false;
						Console.WriteLine(isRowsValid);
						break;
					}
					isRowsValid = true;
					
				}
            }
        }
		
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

// 1, 4, 2, 7, 9



class Program
{
    static void Main()
    {
        int[,] someSudokuBoard = {
        { 3, 1, 6, 5, 7, 8, 4, 2, 9 },
        { 5, 2, 9, 1, 3, 4, 7, 6, 8 },
        { 4, 8, 7, 6, 2, 9, 5, 3, 1 },
        { 2, 6, 3, 0, 1, 5, 9, 8, 7 },
        { 9, 7, 4, 8, 6, 0, 1, 2, 5 },
        { 8, 5, 1, 7, 9, 2, 6, 4, 3 },
        { 1, 3, 8, 0, 4, 7, 2, 0, 6 },
        { 6, 9, 2, 3, 5, 1, 8, 7, 4 },
        { 7, 4, 5, 0, 8, 6, 3, 1, 0 }};

        Sudoku newSudoku = new Sudoku(9, 9, someSudokuBoard);

        newSudoku.Print();
		newSudoku.checkSudoku();
    }
}































/*for (int i = 0; i > array.Length; i = i + 1)
{
	if (array[i] )
}*/





















