using System;

class Program
{
    static void Main()
    {
        double F;

		for (double C = -5; C <= 40; C = C + 0.5)
		{
			F = 32+(9/5)*C;
			Console.WriteLine(string.Format("{0,-6} {1,-6}", C , F));
		}
    }
}
