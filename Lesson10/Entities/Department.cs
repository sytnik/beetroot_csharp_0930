using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Lesson10.Entities;

[Serializable]
public class Department
{
    public int Id { get; set; }
    [XmlIgnore, JsonIgnore] public string Name { get; set; }

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