using System.Text.Json;
using Bogus;
using Lesson20Lib.Entities;
using Person = Lesson20Lib.Entities.Person;

namespace Lesson20Lib;

public static class SomeTesting
{
    public static List<Company> SomeCompanies;

    public static void SomeSerializationTesting()
    {
        if (!File.Exists("Users.json"))
        {
            InitialDataSeed();
        }

        SerializeCompanies("Users.json");
        DeserializeCompanies("Users.json");
    }

    private static void DeserializeCompanies(string path)
    {
        using var fileStream = new FileStream(path,
            FileMode.OpenOrCreate);
        var companies = JsonSerializer
            .Deserialize<List<Company>>(fileStream);
        SomeCompanies = companies ?? SomeCompanies;
    }

    private static void SerializeCompanies(string path)
    {
        using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
        JsonSerializer.Serialize(fileStream, SomeCompanies);
    }

    private static void InitialDataSeed()
    {
        var personSeed = new Faker<Person>()
            .RuleFor(person => person.Id,
                faker => faker.IndexFaker + 1)
            .RuleFor(person => person.Name,
                faker => faker.Name.FullName())
            .RuleFor(person => person.Phone,
                faker => faker.Phone.PhoneNumber())
            .RuleFor(person => person.Address,
                faker => faker.Address.FullAddress())
            .RuleFor(person => person.City,
                faker => faker.Address.City())
            .RuleFor(person => person.Region,
                faker => faker.Address.Country());
        var persons = personSeed.Generate(100);
        var departmentSeed = new Faker<Department>()
            .RuleFor(department1 => department1.Id,
                faker => faker.IndexFaker + 1)
            .RuleFor(department1 => department1.Name,
                faker => faker.Commerce.Department())
            .RuleFor(department1 => department1.Persons,
                faker => faker.PickRandom(persons, 30)
                    .ToList());
        var departments = departmentSeed.Generate(20);
        var companyFaker = new Faker<Company>()
            .RuleFor(company => company.Id,
                faker => faker.IndexFaker + 1)
            .RuleFor(company => company.Name,
                faker => faker.Company.CompanyName())
            .RuleFor(company => company.Departments,
                faker => faker
                    .PickRandom(departments, 10)
                    .ToList());
        SomeCompanies = companyFaker.Generate(3);
    }
}