//https://www.printsudoku.com/da/sudoku/teknikker.html
//Krydsning af rækker og kolonner



class SodukoSolver
{
    public int[,] sodukoBoard;
    public int[] currentRow = new int[9];
    public int[] currentColumn = new int[9];
    public int[] currentSqaure = new int[9];
    public int[] nums = new int[9];

    public SodukoSolver (int[,] sodukoBoard)
    {
        this.sodukoBoard = sodukoBoard;
    }


}