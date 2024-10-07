/*
Any live cell with fewer than two live neighbours dies, as if by underpopulation.  1 - 0
Any live cell with two or three live neighbours lives on to the next generation.    1 - 1
Any live cell with more than three live neighbours dies, as if by overpopulation.   1 - 0
Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.    0 - 1
*/

class Cell
{
    public bool alive = false;
    protected Cell[] neighbors = new Cell[8];
    public int row, column;
    
    public Cell(int row, int column)
    {
        this.row = row;
        this.column = column;
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

    public void UpdateCell()
    {
        if (!alive && GetAliveNeighbors() == 3)
        {
            ChangeState();
        }

        if (alive && (GetAliveNeighbors() < 2 || GetAliveNeighbors() > 3))
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        alive = !alive;
    }
}