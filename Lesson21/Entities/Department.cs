using MessagePack;

namespace Lesson21.Entities;

[MessagePackObject]
public class Department
{
    [Key(0)]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Person> Persons { get; set; }

    public Department()
    {
    }

    public Department(int id, string name, List<Person> persons)
    {
        Id = id;
        Name = name;
        Persons = persons;
    }
}