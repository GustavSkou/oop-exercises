int Fac(int num)
{
    if (num == 1)               // Stop case
    {
        return 1;               // This will be multiplied to the total because function "Fac(num - 1)" has called it, and its final value 
    }                           // will then be this and since "return 1" does not recall the function this is the final step.
                                
    return num * Fac(num - 1);  // return num * --num * --num * 1
}

Console.WriteLine(Fac(4));