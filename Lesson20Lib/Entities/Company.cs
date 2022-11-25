namespace Lesson20Lib.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Department> Departments { get; set; }

    // public Company()
    // {}
    //
    // public Company(int id, string name, List<Department> departments)
    // {
    //     Id = id;
    //     Name = name;
    //     Departments = departments;
    // }
}