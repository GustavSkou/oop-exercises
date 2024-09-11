using System;

class Program
{
    static void Main()
    {
        int someInt = 100;
        double someDouble = 100.1;

        someInt = (int) someDouble + someInt;
        
        Console.WriteLine(someInt);
    }
}