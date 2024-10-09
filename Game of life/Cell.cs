class Cell
{
    public bool currentState = false, nextState;
    private int aliveNeighbors;
    private int row, column;
    
    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
    
    public int GetAliveNeighbors(Cell cell, Cell[,] world) 
    {
        aliveNeighbors = 0;
        
        for (int row = -1; row <= 1; row++)
        {
            for (int column = -1; column <= 1; column++)
            {
                if (row == 0 && column == 0) // Skip the cell itself
                {
                    continue;
                }

                int neighborRow = cell.row + row;
                int neighborColumn = cell.column + column;

                

                if (neighborRow < 0) // Check for out off bounds
                {
                    neighborRow = world.GetLength(0) - 1;
                }
                if (neighborRow >= world.GetLength(0))
                {
                    neighborRow = 0;
                }


                if (neighborColumn < 0)
                {
                    neighborColumn = world.GetLength(1) - 1;
                }
                if (neighborColumn >= world.GetLength(1))
                {
                    neighborColumn = 0;
                }

                

                if (world[neighborRow, neighborColumn].currentState)
                {
                    aliveNeighbors++;
                }
            }
        }
        return aliveNeighbors;
    }

    public void GetNextState(Cell cell, Cell[,] world) //update
    {
        if (!currentState && GetAliveNeighbors(cell, world) == 3)
        {
            ChangeNextState();
            return;
        }

        if (currentState && (GetAliveNeighbors(cell, world) < 2 || GetAliveNeighbors(cell, world) > 3))
        {
            ChangeNextState();
            return;
        }

        if (currentState && (GetAliveNeighbors(cell, world) == 2 || GetAliveNeighbors(cell, world) == 3))
        {
            KeepNextState();
            return;
        }
    }

    public void ChangeState()
    {
        currentState = !currentState;
    }

    public void KeepNextState()
    {
        nextState = currentState;
    }

    public void ChangeNextState()
    {
        nextState = !currentState;
    }

    public void SetNextState()
    {
        currentState = nextState;
    }
}