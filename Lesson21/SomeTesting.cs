using System.Globalization;
using System.Text.Json;
using Bogus;
using CsvHelper;
using Lesson21.Entities;
using MessagePack;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Person = Lesson21.Entities.Person;

namespace Lesson21;

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
        SerializeCompanyEmployeesToCsv("Users.csv");
        DeserializeEmployeesFromCsv("Users.csv");
        SerializeCompaniesToYaml("Users.yaml");
        DeserializeCompaniesYaml("Users.yaml");
        SerializeCompaniesToMessagePack("Users.bin");
        DeserializeCompaniesFromMessagePack("Users.bin");
    }

    private static void SerializeCompanyEmployeesToCsv(string path)
    {
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(SomeCompanies.First().Departments
            .SelectMany(department => department.Persons));
    }

    private static void DeserializeEmployeesFromCsv(string path)
    {
        List<Person> persons;
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            persons = csv.GetRecords<Person>().ToList();
        }

        foreach (var department in SomeCompanies.First().Departments)
        {
            department.Persons = persons
                .Where(person => person.DepartmentId == department.Id).ToList();
        }
    }

    private static void SerializeCompaniesToYaml(string path)
    {
        using var streamWriter = new StreamWriter(path);
        var serializer = new SerializerBuilder()
            .WithNamingConvention(LowerCaseNamingConvention.Instance)
            .Build();
        serializer.Serialize(streamWriter, SomeCompanies);
    }

    private static void SerializeCompaniesToMessagePack(string path)
    {
        using var fileStream = new FileStream(path, FileMode.OpenOrCreate,
            FileAccess.ReadWrite);
        // var resolver = MessagePack.Resolvers.AttributeFormatterResolver.Instance;
        // var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
        MessagePackSerializer.Serialize(fileStream, SomeCompanies);
    }

    private static void DeserializeCompaniesYaml(string path)
    {
        using var streamReader = new StreamReader(path);
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(LowerCaseNamingConvention.Instance)
            .Build();
        SomeCompanies = deserializer.Deserialize<List<Company>>(streamReader);
    }

    private static void DeserializeCompaniesFromMessagePack(string path)
    {
        using var fileStream = File.OpenRead(path);
        SomeCompanies = MessagePackSerializer.Deserialize<List<Company>>(fileStream);
    }

    private static void SerializeCompanies(string path)
    {
        using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
        JsonSerializer.Serialize(fileStream, SomeCompanies);
    }

    private static void DeserializeCompanies(string path)
    {
        using var fileStream = new FileStream(path,
            FileMode.OpenOrCreate);
        var companies = JsonSerializer
            .Deserialize<List<Company>>(fileStream);
        SomeCompanies = companies ?? SomeCompanies;
    }

    private static void InitialDataSeed()
    {
        var range = Enumerable.Range(1, 20);
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
                faker => faker.Address.Country())
            .RuleFor(person => person.PostalCode,
                faker => faker.Address.ZipCode())
            .RuleFor(person => person.DepartmentId,
                faker => faker.PickRandom(range));
        var persons = personSeed.Generate(300);
        var departmentSeed = new Faker<Department>()
            .RuleFor(department1 => department1.Id,
                faker => faker.IndexFaker + 1)
            .RuleFor(department1 => department1.Name,
                faker => faker.Commerce.Department());
        // .RuleFor(department1 => department1.Persons,
        //     faker => faker.PickRandom(persons, 30)
        //         .ToList()
        var departments = departmentSeed.Generate(20);
        foreach (var department in departments)
            department.Persons = persons
                .Where(person => person.DepartmentId == department.Id).ToList();
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