class World : InfoBar
{
    public Cell[,] world;
    private int rows, columns;
    private int runTimes;

    public World(int rows, int columns, int runTimes)
    {
        this.runTimes = runTimes;
        this.rows = rows;
        this.columns = columns;
        this.world = new Cell[rows, columns];

        for(int row = 0; row < rows; row++)
        {
            for(int column = 0; column < columns; column++)
            {
                world[row,column] = new Cell(row, column);
            }
        }
    }
    public void Run()
    {
        for (int runs = 0; runs < runTimes; runs++)
        {
            Update();
            Print();
            Thread.Sleep(250);
        }
    }
    public void ChangeCell(int row, int column)
    {
        world[row, column].ChangeState();
    }

    private void Update()
    {
        foreach(Cell cell in world)
        {
            cell.GetNextState(cell, world);
        }
        foreach(Cell cell in world)
        {
            cell.SetNextState();
        }

        NextGeneration();
    }

    private void Print()
    {
        Console.Clear();

        DisplayInfoBar();

        for(int row = 0; row < rows; row++)
        {
            Console.WriteLine();

            for(int column = 0; column < columns; column++)
            {
                char cellToChar;
                if (world[row, column].currentState)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    cellToChar = '#';
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    cellToChar = '.';
                }
                Console.Write($" {cellToChar} ");
            }
        }  
    }
}