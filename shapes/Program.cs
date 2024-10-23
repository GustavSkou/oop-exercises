class Program
{
    static void Main()
    {
        //Circle circle = new Circle();
        Shape circle = new Circle();

        circle.Draw();

        if (circle is Shape)
        {
            Console.WriteLine("true");
        }
    }
}