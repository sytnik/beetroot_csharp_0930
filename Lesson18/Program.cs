using Bogus;
using Lesson18;

var intList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};


var faker = new Faker<User>()
    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
    .RuleFor(u => u.Name, f => f.Name.FullName())
    .RuleFor(u => u.Email, f => f.Internet.Email())
    .RuleFor(u => u.Password, f => f.Internet.Password())
    .RuleFor(u => u.BirtDate, f => f.Date.Past(30))
    .UseSeed(123);
var users = faker.Generate(1000);

var faker2 = new Faker<SmallUser>()
    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
    .RuleFor(u => u.Name, f => f.Name.FullName())
    .RuleFor(u => u.Email, f => f.Internet.Email());
var users2 = faker2.Generate(200);
var users3 = new List<object>();
users3.AddRange(users);
users3.AddRange(users2);

var smallusers = users3
    .Where(u =>
        (int) u.GetType().GetProperty("Id").GetValue(u, null) < 50)
    .OfType<SmallUser>()
    .ToList();

var anyof9 = intList.Any(i => i == 9);
var allof3 = intList.All(i => i == 3);
var contains5 = intList.Contains(5);
// var max = intList.Max();
var min = intList.Min();
var max = users.Max(u => u.Id);
var maxby = users.MaxBy(u => u.Id);
var sortedUsers = users
    .OrderBy(u => u.Name)
    .ThenBy(u => u.BirtDate)
    .ToList();
var elementat = users.ElementAt(250);
var range = users.GetRange(500, 10);
var take = users.Take(new Range(10, 20));
var takelast = users.TakeLast(10);
var takewhile = users
    .TakeWhile(u => u.Id < 50).ToList();
var repeat = Enumerable.Repeat(Guid.NewGuid(), 10).ToList();
var zip = users
    .Zip(intList, (u, i) => $"{i} - {u.Name}")
    .ToList();
var userswhere1 = users
    .Where(u => u.BirtDate > new DateTime(2000, 12, 12))
    .Select(u => new SomeData(u.Id, u.Name))
    .OrderBy(sd => sd.Name)
    .ToList();

var groupby = users
    .GroupBy(u => u.Name.ElementAt(0))
    .OrderBy(gr => gr.Key)
    .ToList();

var groupby1 = users
    .GroupBy(u => u.Name.ElementAt(0))
    .OrderBy(gr => gr.Key)
    .Select(gr => $"{gr.Key} - {gr.Count()} users")
    .ToList();

var selectgroup = groupby
    .Where(gr => gr.Key < 'E')
    .SelectMany(u => u).ToList();

var sum = intList.Sum();
var idsum = users.Sum(user => user.Id);

Console.WriteLine();

public record SomeData(int Id, string Name);