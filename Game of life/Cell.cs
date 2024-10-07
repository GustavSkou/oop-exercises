/*
Any live cell with fewer than two live neighbours dies, as if by underpopulation.  1 - 0
Any live cell with two or three live neighbours lives on to the next generation.    1 - 1
Any live cell with more than three live neighbours dies, as if by overpopulation.   1 - 0
Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.    0 - 1
*/

class Cell
{
    public bool currentState = false, nextState;
    protected int aliveNeighbors;
    public int row, column;
    
    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
    public int GetAliveNeighbors(Cell cell, Cell[,] world) 
    {
    int aliveNeighbors = 0;
    
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

            if (neighborRow < 0 || neighborRow >= world.GetLength(0) || neighborColumn < 0 || neighborColumn >= world.GetLength(1)) // Check for out off bounds
            {
                continue;
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