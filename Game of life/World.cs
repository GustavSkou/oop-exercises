class World
{
    public Cell[,] world;
    int rows, columns;

    public World(int rows, int columns)
    {
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

    public void Print()
    {
        Console.Clear();

        for(int row = 0; row < rows; row++)
        {
            Console.WriteLine("");

            for(int column = 0; column < columns; column++)
            {
                char chellToChar = world[row,column].live ? 'X' : 'O';
                
                Console.Write(chellToChar);
            }
        }
    }

}

