
using Lesson20Lib;

int? test = null;

SomeTesting.SomeSerializationTesting();

var someInts = new List<int>{1,2,3,4,5};
var strings = new List<string>();
foreach (var val in someInts)
{
    strings.Add(val.ToString());
}
var strings2 = someInts
    .ConvertAll(x=>$"someint with: {x}");
Console.WriteLine("123");