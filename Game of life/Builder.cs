class Builder
{
    protected int row;
    protected int column;

    protected void GetInput()
    {
        var movement = Console.ReadKey(false).Key;

        switch(movement)
        {
            case ConsoleKey.UpArrow:
                row++;
            break;

            case ConsoleKey.LeftArrow:
                column--;
            break;

            case ConsoleKey.RightArrow:
                column++;
            break;

            case ConsoleKey.DownArrow:
                row--;
            break;

            default:

            break;
        }
    }
}