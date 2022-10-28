using Lesson10.Entities;

namespace Lesson11.Classes;

public class SomeDepartment : Department
{
    public SomeDepartment(List<Person> persons) : base(persons)
    {
    }
}