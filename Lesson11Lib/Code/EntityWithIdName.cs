namespace Lesson11.Classes;

public class EntityWithIdName
{
    
    public EntityWithIdName(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public EntityWithIdName()
    {
        Console.WriteLine($"EntityWithIdName");
    }

    public int Id { get; set; }
    public string Name { get; set; }


    public virtual string PrintIdNameFormatted()
    {
        return $"{Id} - {Name}";
    }
    
}