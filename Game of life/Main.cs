class Program
{
    static void Main()
    {
        World world = new World(15, 25, 50);

        world.ChangeCell(1,1);
        world.ChangeCell(1,2);
        world.ChangeCell(1,3);
        world.ChangeCell(2,0);
        world.ChangeCell(2,1);
        world.ChangeCell(2,2);

        world.ChangeCell(5,4);
        world.ChangeCell(5,5);
        world.ChangeCell(5,6);
        
        world.Run();
    }
}