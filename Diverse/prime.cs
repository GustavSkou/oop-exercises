using System;

class FindPrimes
{
static void Main()
    {
        int primeCount = 0; 
        int range = 1000000;     
        bool isPrime; 

        if(2 % 2 == 0)
        {
            Console.WriteLine(2);
            primeCount++;
        }
        for (int i = 3; i < 1000000; i = i + 2)     // (i) starts at 3, so that we only need to look at all uneven numbers
        {
            isPrime = true; 
            for (int n = 2; n < i/2; n++)
            {
                if(i % n == 0)                      // If (i/n) does not have a reminder, it cannot be a prime. Since we have excluded 1 and i it self
                {
                    isPrime = false;
                    break;                          // We can now move on to the next number to test
                }
            }
            if (isPrime == true)
            {
                Console.Write(string.Format("{0,7}", i));
                primeCount++;
            }
        }
        Console.WriteLine("\nprimes in " + range + " : " + primeCount);
    }
}