using System;

class someProgram
{
    static void Main()
    {
        double pi = 3.14159265359;
        double radius = Convert.ToInt32(Console.ReadLine());

        double cirkelAreal = pi * Math.Pow(radius, 2);
        Console.WriteLine(cirkelAreal);
    }   
}