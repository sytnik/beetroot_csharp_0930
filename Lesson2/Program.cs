// byte value

byte byteValue = 5;
sbyte sbyteValue = 5;
int mulResult = byteValue * sbyteValue;
int divResult = byteValue / sbyteValue;
var partResult = byteValue % sbyteValue;
int myVar;
myVar = 5;

Console.WriteLine("Result " + mulResult);
Console.WriteLine("divResult " + divResult);
Console.WriteLine("partResult " + partResult);

int value1 = 3;
int value2 = 3;
Console.WriteLine(++value1);
Console.WriteLine(value2++);

var bool1 = true;
var bool2 = false;
Console.WriteLine($"AND: {bool1 && bool2}");
Console.WriteLine($"OR: {bool1 || bool2}");
Console.WriteLine($"EQUAL: {bool1 == bool2}");
Console.WriteLine($"NOT bool1: {!bool1}");
Console.WriteLine($"NOT bool2: {!bool2}");
Console.WriteLine($"XOR: {bool1 ^ bool2}");

int first = 1;
int second = 2;
int third = 3;
Console.WriteLine($"first > second: {first > second}");
Console.WriteLine($"first < second:{first < second}");
Console.WriteLine($"first == second:{first == second}");
Console.WriteLine($"first != third:{first != third}");
Console.WriteLine($"second != third:{second != third}");
Console.WriteLine($"first >= third: {first >= third}");
Console.WriteLine($"first <= third: {first <= third}");

var bool3 = true;
var bool4 = false;
var bool5 = false;
Console.WriteLine($"AND (bool): {bool3 & bool4}");
Console.WriteLine($"AND (bool): {bool3 & bool4 & bool5}");
Console.WriteLine($"OR (bool): {bool3 | bool4}");
Console.WriteLine($"OR (bool): {bool3 | bool4 | bool5}");

var var1 = 10; // 1010
var var2 = 3; // 0011
// and    0010 -> 2
// or     1011 -> 11
Console.WriteLine(var1 & var2);
Console.WriteLine(var1 | var2);
Console.WriteLine(var1 << var2); // 10 << 3  00001010  01010000
Console.WriteLine(var1 >> var2); // 10 >> 3  00001010  00000001

var bigNum = 1L * 2L;

// datetime 
string str1 = null;
int? int1 = null;
DateTime? dt1 = DateTime.Now.AddHours(1000);
DateTime dt2 = new DateTime(2022, 10, 4, 5, 5, 5);
Console.WriteLine(DateOnly.FromDateTime(DateTime.Now.AddHours(1000)));

Console.WriteLine(DateTime.Today);
Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTime.UtcNow);
string str4 = (first + second).ToString();
string str5 = $"{first + second}";
string str6 = dt1.Value.ToString();
Console.WriteLine(dt1.Value.ToString());
Console.WriteLine(dt1.Value.ToShortDateString());
Console.WriteLine(dt1.Value.ToShortTimeString());
Console.WriteLine(dt1.Value.ToLongDateString());
Console.WriteLine(dt1.Value.ToLongTimeString());
Console.WriteLine(dt1.Value.ToString("hh:mm-MM.yyyy"));

int value = 6;
if (value < 0)
{
    // Console.WriteLine("not null");
    Console.WriteLine("action 1");
}
else if (value < -1)
{
    Console.WriteLine("action 2");
}
else if (value < 4)
{
    Console.WriteLine("action 3");
}
else
{
    Console.WriteLine("action 4");
}

// math by two numbers

int i1 = 1, i2 = 2, i3 = 3;

Console.WriteLine("begin program...");
Console.WriteLine("input num1: ");
var num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("input num2: ");
var num2 = Convert.ToInt32(Console.ReadLine());
var result = num1 * num2;
Console.WriteLine($"result of num1 * num2: {result}");