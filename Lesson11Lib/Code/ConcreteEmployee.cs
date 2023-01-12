namespace Lesson11Lib.Code;

public class ConcreteEmployee : Employee
{
    public ConcreteEmployee()
    {
        SomeUniqId = Guid.NewGuid();
    }
}