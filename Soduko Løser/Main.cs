﻿class Program
{
    static void Main() 
    {
        int[,] extreme = 
        {
            {0, 0, 0,  7, 5, 0,  4, 0, 0}, 
            {0, 0, 0,  0, 0, 0,  0, 7, 0}, 
            {0, 2, 0,  0, 9, 0,  0, 5, 0}, 
            
            {0, 0, 9,  0, 0, 2,  0, 0, 0}, 
            {0, 0, 0,  0, 0, 8,  1, 0, 6},
            {0, 1, 0,  4, 0, 0,  0, 0, 0},
            
            {5, 9, 7,  0, 0, 0,  0, 0, 0},
            {4, 0, 0,  0, 0, 0,  0, 0, 3},
            {2, 0, 0,  0, 0, 0,  0, 8, 4}
        };

        int[,] expert = 
        {
            {0, 4, 0,  0, 0, 9,  5, 6, 0}, 
            {1, 9, 0,  0, 0, 6,  0, 0, 0}, 
            {8, 0, 3,  4, 0, 0,  0, 9, 0}, 
            
            {0, 0, 0,  0, 0, 8,  4, 7, 0}, 
            {4, 0, 0,  0, 2, 7,  8, 0, 1},
            {0, 0, 0,  5, 0, 3,  0, 2, 0},
            
            {3, 0, 0,  9, 7, 0,  0, 0, 5},
            {0, 0, 8,  0, 0, 0,  0, 0, 4},
            {6, 0, 0,  0, 3, 0,  0, 0, 0}
        };

        int[,] hard = 
        {
            {0, 1, 0,  8, 0, 0,  0, 0, 4}, 
            {7, 0, 0,  0, 6, 0,  0, 0, 0}, 
            {6, 8, 5,  0, 0, 0,  1, 3, 2}, 
            
            {0, 4, 2,  0, 0, 0,  0, 1, 5}, 
            {0, 6, 8,  3, 1, 0,  4, 0, 0},
            {0, 9, 0,  0, 0, 2,  6, 0, 0},
            
            {0, 0, 0,  6, 0, 0,  0, 0, 0},
            {0, 2, 0,  0, 4, 0,  0, 0, 0},
            {0, 7, 0,  1, 9, 0,  0, 5, 0}
        };
        int[,] medium = 
        {
            {0, 0, 7,  0, 0, 0,  8, 0, 0}, 
            {3, 0, 6,  1, 8, 2,  7, 4, 5}, 
            {0, 8, 0,  5, 3, 7,  0, 0, 0},

            {6, 7, 2,  0, 0, 5,  9, 0, 0}, 
            {0, 4, 9,  2, 0, 8,  0, 1, 0},
            {0, 3, 0,  4, 0, 6,  0, 0, 7},

            {7, 6, 0,  8, 0, 0,  4, 0, 9},
            {9, 0, 8,  0, 0, 3,  0, 0, 0},
            {0, 0, 0,  6, 0, 0,  3, 0, 0}
        };
        int[,] easy = 
        {
            {0, 0, 0,  4, 0, 7,  0, 0, 0}, 
            {9, 0, 1,  6, 8, 3,  0, 0, 0}, 
            {0, 2, 0,  0, 0, 5,  0, 7, 0}, 
            
            {0, 0, 0,  8, 0, 1,  0, 5, 0}, 
            {0, 1, 0,  0, 0, 9,  7, 6, 2},
            {7, 3, 4,  0, 5, 6,  0, 0, 0},
            
            {1, 9, 0,  7, 0, 4,  0, 8, 3},
            {0, 4, 0,  5, 9, 8,  0, 2, 6},
            {0, 5, 6,  1, 0, 0,  0, 0, 0}
        };

        int[,] someSudokuBoard = expert;

        
        Sudoku sudoku = new Sudoku(someSudokuBoard);
        
        sudoku.Print();
		sudoku.Solve();
        Console.WriteLine("");
        sudoku.Print();        
    }
}