using Lesson11.Classes;

var employee = new Employee(1, "name", Guid.NewGuid(), "someinfo");
// var employee2 = new Employee();
var persons = new List<Person>
{
    new(1, "name1", Guid.NewGuid()),
    new Employee(2, "name2", Guid.NewGuid(), "some info")
};

// var info1 = ((Employee) persons[0]).SomeInfoField; // not good
var info1 = (persons[1] as Employee)?.SomeInfoField ?? "object cast failed";
var info2 = (persons[0] as Employee)?.SomeInfoField ?? "object cast failed";


Console.WriteLine(employee.PrintIdNameFormatted());
Console.WriteLine("Hello, World!");