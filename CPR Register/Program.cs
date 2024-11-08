class Program
{
    static void Main()
    {
        Person gustav = new Person("Gustav", 21, "270303-9172");
        Person pelle = new Person("Pelle", 21, "140203-2172");
        Person malte = new Person("Malte", 23, "010101-0101");
        Person daniel = new Person("Daniel", 28, "210396-9821");
        Person oliver = new Person("Oliver", 25, "200599-7471");


        List<Person> persons = new List<Person>
        {
            gustav,pelle,malte,daniel,oliver
        };

        Dictionary<string, Person> CprPersonPairs = new Dictionary<string, Person>
        {
            {gustav.Cpr, gustav},
            {pelle.Cpr, pelle},
            {malte.Cpr, malte},
            {daniel.Cpr, daniel},
            {oliver.Cpr, oliver},
        };
        

        foreach(Person person in persons)
        {
            if (person.Cpr == "010101-0101")
            {
                Console.WriteLine(person.ToString());
                break;
            }
        }

        Console.WriteLine(CprPersonPairs["010101-0101"].ToString());
    }
}