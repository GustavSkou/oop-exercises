class Rectangle
{
    public int width;
    public int height;
    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}

class Program
{
    static void Main()
    {
        Rectangle r1 = new Rectangle(2, 2);
        Rectangle r2 = r1;
        r1.width = 3;   //Changes in r1 will change r2, since r2 is "pointing" to r1.

        Console.WriteLine(r2.width);
    }
}