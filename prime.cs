using System;

class Program
{
static void Main()
    {
        bool isPrime = true;

        for (int i = 2; i <= 10000; i++)
        {
            for (int n = 2; n < i/2; n++)
            {
                if(i % n == 0)
                {
                    isPrime = false;
                    break;
                }
                isPrime = true;
            }

            if (isPrime == true)
            {
                Console.WriteLine(i);
            }
        }
    }
}