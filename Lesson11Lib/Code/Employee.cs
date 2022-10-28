namespace Lesson11.Classes;

public class Employee : Person
{
    public Employee(int id, string name, Guid newId, string someInfoField) : base(id, name, newId)
    {
        SomeInfoField = someInfoField;
    }

    public string SomeInfoField { get; set; }

    // internal string Name { get; set; }

    public Employee()
    {
        Console.WriteLine("Employee() called");
    }

    public Employee(int id)
    {
        Id = id;
    }
    
    public void SetName(string name)
    {
        Name = SetNameLogics(name);
    }

    private string SetNameLogics(string name)
    {
        return $"{name}{Guid.NewGuid()}";
    }
    
    public override string PrintIdNameFormatted()
    {
        return $"{Id} <-> {Name}";
    }
}