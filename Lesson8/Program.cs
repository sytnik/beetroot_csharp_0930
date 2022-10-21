using System.Text.RegularExpressions;

var appPath = "D:\\Git\\beetroot-tasks\\Lesson8\\phonebook.csv";
var phonebook = ReadFile(appPath);
AddPhoneBookRecord(appPath);
phonebook = ReadFile(appPath);
Console.WriteLine("searchcustomer");
WorkWithRegex();
var list = SearchCustomerByNumber(Console.ReadLine(), phonebook);
var intisdefault = 3 == default;
Console.WriteLine(
    $"{(list.Any() ? $"{string.Join("\r\n", list)}" : "No customers found")}");


(string, string, string)[] SearchCustomerByNumber(
    string input,
    List<(string, string, string)> collection)
{
    var numericPattern = @"^[0-9]+$"; // рядок, в якому є тільки числа
    var numericRegex = new Regex(numericPattern);
    if (!numericRegex.IsMatch(input)) return new[] {("input error", "", "")};
    return collection.Where(person =>
        person.Item3.Contains(input)).ToArray();
}


(string, string, string)[] SearchCustomer(
    string input,
    List<(string, string, string)> collection) =>
    collection.Where(person =>
        person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase) ||
        person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
        person.Item3.Contains(input)).ToArray();


List<(string FirstName, string LastName, string PhoneNumber)> ReadFile(string path)
{
    string.Equals("123", "244", StringComparison.InvariantCultureIgnoreCase);
    if (!File.Exists(path)) return null;
    var book = new List<(string FirstName, string LastName, string PhoneNumber)>();
    var lines = File.ReadAllLines(path);
    foreach (var line in lines)
    {
        var split = line.Split(",");
        book.Add((split[0], split[1], split[2]));
    }

    return book;
}

void AddPhoneBookRecord(string path)
{
    InputValue(out var firstName, "FirstName");
    InputValue(out var lastName, "LastName");
    InputValue(out var phoneNumber, "PhoneNumber");
    File.AppendAllLines(
        path,
        new[] {$"\r\n{firstName},{lastName},{phoneNumber}"});
}


void InputValue(out string result, string fieldName)
{
    Console.WriteLine($"Enter {fieldName}:");
    result = Console.ReadLine();
    Console.WriteLine($"{fieldName} submitted: {result}");
}

void WorkWithRegex()
{
    var numericPattern = @"^[0-9]+$"; // рядок, в якому є тільки числа
    var numericRegex = new Regex(numericPattern);
    var alphabeticRegex = new Regex(@"^[a-zA-Z]+$"); // рядок, в якомі тільки алфавітні символи
    var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    var str = "123454";
    var isdigit = str.All(c => char.IsDigit(c));
    // перевірка е-меілу
    var match0 = new Regex(@"^[0-9]+$").IsMatch(str);
    var match1 = new Regex(@"^[0-9]+$").IsMatch("etewt");
    var match2 = new Regex(@"^[a-zA-Z]+$").IsMatch("123454");
    var match3 = new Regex(@"^[a-zA-Z]+$").IsMatch("etewt");
    var match4 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        .IsMatch("test@mail.com");
    var match5 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        .IsMatch("test@mail");
}