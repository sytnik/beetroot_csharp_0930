using Bogus;
using Person = Lesson23.Entities.Person;

namespace Lesson23
{
    public class PersonService
    {
        private readonly List<Person> _persons;

        public PersonService()
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
                    faker => faker.Address.Country())
                .RuleFor(person => person.PostalCode,
                    faker => faker.Address.ZipCode());
            _persons = personSeed.Generate(300);
        }

        public List<Person> GetAllPersons() => _persons;

        public List<Person> SearchPersons(string name)
        {
            return _persons.Where(person => person.Name.Contains(name)).ToList();
        }

        public Person? GetPersonById(int id) =>
            _persons.FirstOrDefault(person => person.Id == id);

        public bool DeletePerson(int id)
        {
            var person = _persons.FirstOrDefault(person => person.Id == id);
            if (person != null)
            {
                _persons.Remove(person);
                return true;
            }

            return false;
        }
    }
}