using Lesson23;

namespace Lesson23Nunit.Tests;

[TestFixture]
public class PersonServiceTests
{
    private PersonService _service;

    [SetUp]
    public void Setup()
    {
        _service = new PersonService();
    }

    [Test]
    public void GetAllPersons_Test()
    {
        var persons = _service.GetAllPersons();
        Assert.NotNull(persons);
        Assert.IsNotEmpty(persons);
        Assert.Greater(persons.Count, 300);
        Assert.LessOrEqual(persons.Count, 500);
    }

    [TestCase("", TestName = "SearchPersons_Test ''")]
    [TestCase("al", TestName = "SearchPersons_Test 'al'")]
    public void SearchPersons_Test(string name)
    {
        var persons = _service.SearchPersons(name);
        Assert.NotNull(persons);
    }

    [TestCase(1, TestName = "GetPersonById_Test 1")]
    [TestCase(2, TestName = "GetPersonById_Test 2")]
    public void GetPersonById_Test(int id)
    {
        var person = _service.GetPersonById(id);
        Assert.NotNull(person);
    }

    [TestCase(1, TestName = "GetPersonById_CheckId 1", ExpectedResult = 1)]
    [TestCase(2, TestName = "GetPersonById_CheckId 2", ExpectedResult = 2)]
    [TestCase(0, TestName = "GetPersonById_CheckId 0", ExpectedResult = -1)]
    public int GetPersonById_CheckId(int id)
    {
        var person = _service.GetPersonById(id);
        return person is not null ? person.Id : -1;
    }


    [TestCase(1, TestName = "DeletePerson_Test 1", ExpectedResult = true)]
    [TestCase(-100, TestName = "DeletePerson_Test -100", ExpectedResult = false)]
    public bool DeletePerson_Test(int id)
    {
        return _service.DeletePerson(id);
    }
}