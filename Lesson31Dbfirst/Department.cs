namespace Lesson31Dbfirst;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Data { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}