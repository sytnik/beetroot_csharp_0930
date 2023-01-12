namespace Lesson35MVC.Data;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Data { get; set; }
    public List<User> Users { get; set; }
    public bool IsExpandible { get; set; }
    public DateOnly? Foundation { get; set; }
}