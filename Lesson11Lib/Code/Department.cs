namespace Lesson11.Classes;

public class Department : EntityWithIdName
{
    private List<Person> _employees;

    public Department(List<Person> persons)
    {
        _employees = persons;
    }
    
}