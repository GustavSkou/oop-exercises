class Shape()
{
    public virtual void Draw()
    {
        Console.Write("Shape ");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Circle");
    } 
}

class Triangle : Shape
{
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Triangle");

        
    }
}