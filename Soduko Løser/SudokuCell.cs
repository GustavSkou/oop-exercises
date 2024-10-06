using System.Collections;

class SudokuCell
{
    public int value;
    public ArrayList possibleValues = new ArrayList();

    public SudokuCell (int row, int collumn, ArrayList possibleValues)
    {
        this.possibleValues = possibleValues;        
    }
    public SudokuCell (int row, int collumn, int value)
    {
        this.value = value;        
    }
}