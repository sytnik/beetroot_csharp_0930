object someObj = new TestClass(10);
var type = someObj.GetType();
var assembly = type.Assembly.FullName;
var members = type.GetMembers(
    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
foreach (var member in members)
    Console.WriteLine($"{member.MemberType} - {member}");
var info1 = type.GetProperty("Id",
    BindingFlags.NonPublic | BindingFlags.Instance);
var info2 = type.GetProperty("Name");
info1.SetValue(someObj, 12345);
var intValue = info1.GetValue(someObj);
info2.SetValue(someObj, "12345");
var strValue = info2.GetValue(someObj);
var method1 = type.GetMethod("SomeMethod");
var method2 = type.GetMethod("Output",
    BindingFlags.NonPublic | BindingFlags.Static);
var method3 = type.GetMethod("Output1",
    BindingFlags.NonPublic | BindingFlags.Static);
var returned = method1.Invoke(someObj, new object[] {456});
intValue = info1.GetValue(someObj);
method2.Invoke(someObj, new object[] {456, "789", Guid.NewGuid()});
method3.Invoke(someObj, null);

var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
var handle = Activator.CreateInstance(assemblyName, "TestClass");
var ci = handle.Unwrap();
var val = ci.GetType().GetMethod("SomeMethod")
    .Invoke(ci, new object[] {1});


var faker = new Faker<User>()
    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
    .RuleFor(u => u.Name, f => f.Name.FullName())
    .RuleFor(u => u.Location, f =>
        $"{f.Address.Latitude()},{f.Address.Longitude()}")
    .RuleFor(u => u.About, f => f.Lorem.Paragraph(10))
    .UseSeed(123);
var users = faker.Generate(50);
var rnd = new Random();
for (int i = 0; i < users.Count; i++)
{
    users[i].Friends = users
        .Except(new List<User> {users[i]})
        .OrderBy(x => rnd.Next())
        .Take(5)
        .ToList();
}
// var faker2 = new Faker<User>()
//     .RuleFor(u => u.Id, f => f.IndexFaker + 1)
//     .RuleFor(u => u.Friends, f =>
//         f.PickRandom(users, 5).ToList());
// var users2 = faker2.Generate(50);

// var allusers = users.Zip(users2);
var userdata = users
    .Select(u => new CounterRecord(u.Id,
        u.About.Split(" ").Distinct().ToList(), -1, -1)).ToList();
for (int i = 0; i < userdata.Count; i++)
{
    var user = userdata[i];
    var otherusers = userdata.Except(
        new List<CounterRecord> {user}).ToList();
    for (int j = 0; j < otherusers.Count(); j++)
    {
        var otheruser = otherusers[j];
        var intersectCount = user.Words
            .Intersect(otheruser.Words).Count();
        if (user.Counter < intersectCount)
            user = user with
            {
                Counter = intersectCount, OtherId = otheruser.UserId
            };
    }

    userdata[i] = user;
}

foreach (var user in userdata)
{
    Console.WriteLine($"User {user.UserId} has {user.Words.Count} unique words " +
                      $"and intersection of {user.Counter} words with user id {user.OtherId}");
}

var max = userdata.MaxBy(u => u.Counter);
Console.WriteLine($"The max intersection is between {max.UserId} and {max.OtherId} of {max.Counter} words");

public record CounterRecord(
    int UserId, List<string> Words, int Counter, int OtherId);


public class TestClass
{
    private int Id { get; set; }
    public static string Name { get; set; } = "someName";
    public Guid SomeGuidField;


    public TestClass()
    {
    }

    public TestClass(int id)
    {
        Id = id;
    }

    public int SomeMethod(int id)
    {
        Id = id;
        return id;
    }

    private static void Output(int id, string name, Guid guid)
    {
        Console.WriteLine($"{id} - {name} - {guid}");
    }

    private static void Output1()
    {
        Console.WriteLine($"no params");
    }
}