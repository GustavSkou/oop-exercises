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

        world.ChangeCell(4+10,1+10);
        world.ChangeCell(4+10,2+10);
        world.ChangeCell(4+10,3+10);
        world.ChangeCell(3+10,3+10);
        world.ChangeCell(2+10,2+10);

        world.ChangeCell(13,20);
        world.ChangeCell(14,20);
        world.ChangeCell(13,21);
        world.ChangeCell(14,21);

        world.Run();
    }
}