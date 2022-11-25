using System.Text.Json.Serialization;

namespace Lesson20Lib.Entities;

public class Department
{
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