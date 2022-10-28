namespace Lesson11.Classes;

public class Person : EntityWithIdName
{
    private protected Guid SomeUniqId { get; set; }

    public Person()
    {
        Console.WriteLine("Person() called");
    }

    public Person(int id, string name, Guid newId) : base(id, name)
    {
        SomeUniqId = newId;
    }
}