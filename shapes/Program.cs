class Program
{
    static void Main()
    {
        Shape circle = new Circle();

        circle.Draw();

        if (circle is Shape)
        {
            Console.WriteLine("true");
        }
    }
}