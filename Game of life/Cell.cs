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
    public void GetNeighbors(World world)
    {
        neighbors.Clear();

        
            for(int row = this.row - 1; row < this.row + 1; row++)
            {
                if (row < 0 || row >= world.rows)
                {
                    continue;
                }
                
                for(int column = this.column - 1; column < this.column + 1; column++)
                {
                    if (column < 0 || column >= world.columns)
                    {
                        continue;
                    }

                    if (this.row == row && this.column == column)
                    {
                        continue;
                    }
                    neighbors.Add(new Cell(row, column));
                }
            }
        
        
    }

    public int GetAliveNeighbors()
    {
        int count = 0;
        foreach(Cell cell in neighbors)
        {
            count = cell.alive ? count++ : count;
        }
        return count;
    }

    public void GetNextState(World world) //update
    {
        GetNeighbors(world);

        if (!alive && neighbors.Count == 3)
        {
            ChangeNextState();
            return;
        }

        if (alive && (neighbors.Count < 2 || neighbors.Count > 3))
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