﻿class Program
{
    static void Main()
    {
        World world = new World(9,9);
        world.Print();
        world.ChangeCell(1,1);
        world.ChangeCell(1,2);
        world.ChangeCell(1,3);
        world.Print();
        world.Update();
        world.Print();
        
    }
}