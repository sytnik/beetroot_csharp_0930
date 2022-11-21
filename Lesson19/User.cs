namespace Lesson19;

internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string About { get; set; }
    public List<User> Friends { get; set; }
}