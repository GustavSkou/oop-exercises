/*
Any live cell with fewer than two live neighbours dies, as if by underpopulation.  1 - 0
Any live cell with two or three live neighbours lives on to the next generation.    1 - 1
Any live cell with more than three live neighbours dies, as if by overpopulation.   1 - 0
Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.    0 - 1
*/

class Cell
{
    public bool alive = false, nextState;
    protected List<Cell> neighbors = new List<Cell>();
    public int row, column;
    
    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
    public void GetNeighbors(Cell cell, Cell[,] world)
    {
        cell.neighbors.Clear();
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
                
                cell.neighbors.Add( world[cell.row+x,cell.column+y]);
            }
        }
    }

    public int GetAliveNeighbors(Cell cell)
    {
        int count = 0;
        foreach(Cell neighbor in cell.neighbors)
        {
            count = neighbor.alive ? count++ : count;
        }
        return count;
    }

    public void GetNextState(Cell cell, Cell[,] world) //update
    {
        GetNeighbors(cell, world);

        if (!alive && GetAliveNeighbors(cell) == 3)
        {
            ChangeNextState();
            return;
        }

        if (alive && (GetAliveNeighbors(cell) < 2 || GetAliveNeighbors(cell) > 3))
        {
            ChangeNextState();
            return;
        }
    }

    public void SetNextState()
    {
        alive = nextState;
    }

    public void ChangeNextState()
    {
        nextState = !alive;
    }

    public void ChangeState()
    {
        alive = !alive;
    }
}