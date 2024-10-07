class World
{
    public Cell[,] world, updateWorld;
    public int rows, columns;

    public World(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        this.world = new Cell[rows, columns];
        this.updateWorld = new Cell[rows, columns];

        for(int row = 0; row < rows; row++)
        {
            for(int column = 0; column < columns; column++)
            {
                world[row,column] = new Cell(row, column);
                updateWorld[row,column] = new Cell(row, column);
            }
        }
    }
    public void ChangeCell(int row, int column)
    {
        world[row, column].ChangeState();
        updateWorld[row, column].ChangeState();
    }

    public void Update()
    {
        foreach(Cell cell in world)
        {
            cell.GetNextState(this);
        }
        foreach(Cell cell in world)
        {
            cell.SetNextState();
        }
    }

    public void Print()
    {
        //Console.Clear();

        for(int row = 0; row < rows; row++)
        {
            Console.WriteLine();

            for(int column = 0; column < columns; column++)
            {
                char chellToChar = world[row,column].alive ? 'X' : 'O';
                Console.Write(chellToChar);
            }
        }
    }
}