﻿class Program
{
    static void Main()
    {
        World world = new World(25, 25, 1000);
        world.SetSpeed(50);
        world.StartBuilder();
        world.Run();
    }
}