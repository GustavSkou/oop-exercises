class Person
{
    private string name, cpr;
    private int age;

    public string Name
    {
        get {return name;}
    }

    public string Cpr 
    {
        get {return cpr;}
    }

    public int Age 
    {
        get {return age;}
    }

    public override string ToString()
    {
        return $"{name} {age} {cpr}";
    }

    public Person(string name, int age, string cpr)
    {
        this.name = name;
        this.age = age;
        this.cpr = cpr;
    }

}