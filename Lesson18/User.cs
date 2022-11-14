namespace Lesson18;

internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirtDate { get; set; }

    public User()
    {
    }

    public User(int id, string name, string email, string password, DateTime date)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        BirtDate = date;
    }
}

internal class SmallUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public SmallUser()
    {
    }

    public SmallUser(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}