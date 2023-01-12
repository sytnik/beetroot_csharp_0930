namespace Lesson11Lib.Code;

public class Department : EntityWithIdName
{
    private List<Person> _employees;

    public Department(List<Person> persons)
    {
        _employees = persons;
    }
}