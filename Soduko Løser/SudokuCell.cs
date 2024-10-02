class SudokuCell
{
    public int row;
    public int collumn;
    public int value;
    public int[] possibleValues;

    public SudokuCell (int row, int collumn, int[] possibleValues)
    {
        this.row = row;
        this.collumn = collumn;
        this.possibleValues = possibleValues;
        
    }
    public SudokuCell (int row, int collumn, int value)
    {
        this.row = row;
        this.collumn = collumn;
        this.value = value;
        
    }
}