﻿class Program
{
    static void Main()
    {
        World world = new World(15, 25, 10000);

        world.ChangeCell(4,1);
        world.ChangeCell(4,2);
        world.ChangeCell(4,3);
        world.ChangeCell(3,3);
        world.ChangeCell(2,2); 
        world.Run();
    }
}