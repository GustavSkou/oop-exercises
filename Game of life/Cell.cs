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
        aliveNeighbors = 0;
        for (int x = -1; x < 2; x++)
        {
            if (cell.row + x < 0 || cell.row + x >= world.GetLength(0) || cell.row == x) // Out of range or itself
            {
                continue;
            }
            
            for(int y = -1; y < 2; y++)
            {
                if (cell.column + y < 0 || cell.column + y >= world.GetLength(1) || cell.column == y) // Out of range of itself
                {
                    continue;
                }
                
                if (world[cell.row + x,cell.column + y].currentState)
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