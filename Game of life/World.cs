class World : InfoBar
{
    public Cell[,] world;
    private int rows, columns;
    private int runTimes;
    private int speed = 250;

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
            Thread.Sleep(speed);
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
    private void Print(int selectedRow, int selectedColumn)
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
                if (row == selectedRow && column == selectedColumn)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write($" {cellToChar} ");
            }
        }  
    }
    public void SetSpeed(int milliseconds)
    {
        speed = milliseconds;
    }

    public void StartBuilder()
    {
        Print();
        GetInput();   
    }

    protected void GetInput()
    {
        int row = 0, column = 0;
        bool isBuilding = true;

        while(isBuilding)
        {
            var movement = Console.ReadKey(false).Key;

            switch(movement)
            {
                case ConsoleKey.UpArrow:
                    row--;
                break;

                case ConsoleKey.LeftArrow:
                    column--;
                break;

                case ConsoleKey.RightArrow:
                    column++;
                break;

                case ConsoleKey.DownArrow:
                    row++;
                break;

                case ConsoleKey.M:
                    isBuilding = !isBuilding; 
                break;

                case ConsoleKey.Spacebar:
                    ChangeCell(row, column);
                break;

                default:
                break;
            }
            Print(row, column);
        
        }
    }

}