var str = Console.ReadLine();
var isCorrect = DateTime.TryParse(str, out var value);

if (isCorrect)
    Console.WriteLine($"Input was: {value}");
else
    Console.WriteLine("Incorrect input");

Console.WriteLine("Incorrect input");

for (var i = 0; i < 10; i++)
{
    Console.WriteLine(Output(i, $"{i + 1}"));
}


string Output(int value1, string value2)
{
    return value1 % 2 == 0 ? $"num {value1} is even" : $"num {value1} is odd, {value2}";
}


var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};


foreach (int num in list)
{
    Console.WriteLine(num % 2 == 0 ? $"num {num} is even" : $"num {num} is odd");
}

var line = Console.ReadLine();
var isSuccess1 = int.TryParse(line, out var intValue2);
if (isSuccess1)
{
    Console.WriteLine($"Input success: {intValue2}");
}
else
{
    Console.WriteLine($"Input not success, {line}");
}

var str2 = Console.ReadLine();
Console.WriteLine(
    $"{(int.TryParse(str2, out var intValue) ? $"Input success: {intValue}" : $"Input not success, {str2}")}");
Console.ReadLine();

for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }

    if (i > 2)
    {
        break;
    }

    Console.WriteLine(i);
}

Console.WriteLine(1);

int.TryParse(Console.ReadLine(), out var a);
int b = 50;
int c;
string s = "123";

while (true)
{
    var str1 = Console.ReadLine();
    if (str1 == "exit") break;
    Console.WriteLine(str1);
}

switch (b)
{
    case >= 20 and <= 60: // [20; 60]
        break;
    case > 1000:
        b = 10;
        break;
    case < 1000:
        b = 10;
        break;
    case <= 100 or > 200: // [20; 60]
        Console.WriteLine("case");
        break;
}

switch (s)
{
    case "1":
    case "avcx":
        b = 2;
        break;
    case "34":
        b = 4;
        break;
    case "335":
        b = 4;
        break;
    default:
        b = 5;
        break;
}

b = a switch
{
    1 => 2,
    2 => 3,
    3 => 4,
    4 => 4,
    _ => 5
};

Console.WriteLine($"Result b: {b}");

string str3;
int result;

str3 = Console.ReadLine();
while (!int.TryParse(str3, out result))
{
}

do
{
    str3 = Console.ReadLine();
} while (!int.TryParse(str3, out result));

Console.WriteLine($"{(result == 0 ? $"Input success: {result}" : $"Input not success, {str3}")}");
Console.ReadLine();

public class Test
{
    public int method1(int p1, int p2)
    {
        return 1;
    }

    public int method1(int p1, int p2, int p3)
    {
        return 2;
    }
}