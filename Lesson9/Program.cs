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

object newobj = 1;

var myclassObj = new MyClass();
var myclassObjWithValue = new MyClass(15);
myclassObj.Number = 5;
myclassObj.Name = "123x";
var int1 = myclassObj.Number;
var int2 = MyStaticClass.Number;

try
{
    SomeMethod();
}
catch (Exception ex)
{
    Console.WriteLine($"exception at top level, {ex.StackTrace}");
}

void SomeMethod()
{
    string str = "";
    int i = 0;
    try
    {
        str = Console.ReadLine();
        var intValue = int.Parse(str);
        var array = new int[intValue];
        for (; i < array.Length - 1; i++)
        {
            array[i] = i + 1;
        }

        var elem = array.ElementAtOrDefault(8);
        if (elem is 0)
            throw new ArgumentException("Invalid index provided");
        Console.WriteLine("other stuff");
    }
    catch (FormatException)
    {
        //Console.WriteLine($"FormatException occured, user input was: {str}");
        throw;
    }
    catch (IndexOutOfRangeException)
    {
        //Console.WriteLine($"IndexOutOfRangeException occured at {i + 1}-th element");
        throw;
    }
    catch (Exception ex)
    {
        //if (System.Diagnostics.Debugger.IsAttached)
        //{
        //    Console.WriteLine("stacktrace");
        //    Console.WriteLine(ex.StackTrace);
        //}
        //else
        //{
        //    Console.WriteLine(ex.Message);
        //}

        throw;
    }
    finally
    {
        Console.WriteLine("finally occured");
    }
}


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


[Serializable]
public class MyClass
{
    public int Number { get; set; }

    private string _stringValue;

    public string GetStrValue() => _stringValue;

    public void SetStrValue(string userValue) =>
        _stringValue = userValue.All(c => char.IsDigit(c)) ? userValue : _stringValue;


    public string Name
    {
        get => _stringValue;
        set
        {
            if (value.All(c => char.IsDigit(c)))
                _stringValue = value;
        }
    }

    public MyClass()
    {
    }

    public MyClass(int number)
    {
        Number = number;
    }

    public int GetNumber()
    {
        return Number;
    }
}

public static class MyStaticClass
{
    public static int Number = 10;

    public static int GetStaticNumber()
    {
        return 7;
    }
}