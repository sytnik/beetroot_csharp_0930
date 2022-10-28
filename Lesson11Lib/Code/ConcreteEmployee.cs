namespace Lesson11.Classes;

public class ConcreteEmployee : Employee
{
    public ConcreteEmployee()
    {
        SomeUniqId = Guid.NewGuid();
    }
}