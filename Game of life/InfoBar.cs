class InfoBar
{
    private string infoBarText = "generation number:";
    private long generation = 0;

    protected void NextGeneration()
    {
        generation++;
    }

    protected void DisplayInfoBar()
    {
        Console.Write($"{infoBarText} {generation}");
    }


}