//int result = 1;
//result = Method1(10, "1");
//Console.WriteLine($"Result {result}");

int? int1 = 5;
List<int> list = new List<int> {1, 34, 5, 4};
list.Remove(34);
int result = 0;
Console.WriteLine($"Result {new TestClass().Method12(ref int1, 7)}");
Console.WriteLine($"Result {new TestClass().Method12(ref int1, 7)}");
IncrementList(ref result, list, 1, 2, 3, 4, 5, 6);
Console.WriteLine($"Result: {string.Join(",", list)}");
ReqMethod(5);
var str = new TestClass().Method12(ref int1, 2);
Console.WriteLine(str);
var myarray = new[] {1, 2, 3};
Array.Reverse(myarray);
Array.Resize(ref myarray, 10);
for (int i = 3; i < myarray.Length; i++)
{
    myarray[i] = i + 1;
}

myarray = myarray.Where(value => value % 2 == 0 && value > 2).ToArray();
var test = myarray.Where(value => value != 7);
var strArray = new string[3];
strArray[0] = "12345";
strArray[1] = "574578";
strArray[2] = "   464778    ";
var matches =
    strArray
        .Where(s => s.Trim().StartsWith("46"))
        .Select(s => s.Trim())
        .ToList();
var test1 = string.IsNullOrEmpty(strArray[2]);
var test2 = string.IsNullOrWhiteSpace(strArray[2]);
Console.WriteLine(str);

string ConcatString(string param1, string param2)
{
    return param1 + " " + param2;
}


int ReqMethod(int param)
{
    if (param < 100) return ReqMethod(++param);
    return param;
}

int Method1(int var1 = 5, string var2 = "10")
{
    return var1 * int.Parse(var2);
}

void IncrementList(ref int sum, List<int> result, params int[] list2)
{
    //result = new List<int>();
    for (int i = 0; i < list2.Length; i++)
    {
        result.Add(list2[i] += 1);
    }

    foreach (var elem in list2)
    {
        result.Add(elem + 1);
    }

    sum = list.Sum();
}

public class TestClass
{
    public int? Method12(ref int? var1, int var2 = 10) =>
        --var1 * var2;

    public string Method12(ref int? var1, int var2 = 10, int required = 6) =>
        $"{--var1 * var2}";
}