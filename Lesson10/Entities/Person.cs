namespace Lesson10.Entities;

[Serializable]
public class Person
{
    public const string PartialDepartmentId = "+38";
    public int Id { get; set; }
    public string Name { get; set; }

    private string Phone;

    public string GetPhone() => $"{PartialDepartmentId}{Phone}";

    public void SetPhone(string value) =>
        Phone = value.All(ch => char.IsDigit(ch)) ? value : Phone;


    public Person()
    {
    }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}