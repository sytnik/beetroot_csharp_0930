namespace Lesson20Lib.Entities;

public class Person
{
    public const string PartialDepartmentId = "+38";
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }

    public string GetPhone() => $"{PartialDepartmentId}{Phone}";

    public void SetPhone(string value) =>
        Phone = value.All(char.IsDigit) ? value : Phone;


    public Person()
    {
    }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}