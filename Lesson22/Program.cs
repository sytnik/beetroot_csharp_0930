using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

var stopwatch = new Stopwatch();
stopwatch.Start();
PrintOutput();
Console.WriteLine($"Sync elapsed time:{stopwatch.ElapsedMilliseconds}");
stopwatch.Restart();
await PrintOutputAsync();
Console.WriteLine($"Async elapsed time:{stopwatch.ElapsedMilliseconds}");

var number1 = int.Parse(Console.ReadLine());
Console.WriteLine($"The number 1 is {number1}");
var number2 = int.Parse(Console.ReadLine());
Console.WriteLine($"The number 2 is {number2}");

async Task<List<string>> AsyncEnumerableToList(IAsyncEnumerable<string> asyncEnumerable)
{
    var list = new List<string>();
    await foreach (var elem in asyncEnumerable)
    {
        list.Add(elem);
    }

    return list;
}

var asyncWork = 0;
var taskOne = DoSomeAsyncWork(number1);
var taskTwo = DoSomeAsyncWork(number2);
var someFinalResult = Task.WhenAll(taskOne, taskTwo);
try
{
    Console.WriteLine($"The result is: {string.Join(',', await someFinalResult)}");
}
catch (Exception e)
{
    if (someFinalResult.Exception is not null)
    {
        foreach (var ex in someFinalResult.Exception.InnerExceptions)
        {
            Console.WriteLine($"The exception was thrown: {ex.Message}");
        }
    }

    Console.WriteLine($"Are all tasks faulted: {someFinalResult.IsFaulted}");
}

var data = new SomeDataStorage();
var elements = data.GetElementAsync();

var output = await AsyncEnumerableToList(elements);
Console.WriteLine($"The total data received:{string.Join(',', output)}");
Console.WriteLine($"The method is:{ReflectionExt.IsAsyncMethod(typeof(SomeDataStorage), "SomeAsync")}");

Console.WriteLine($"The collection received: {string.Join(':', elements)}");


try
{
    asyncWork = await DoSomeAsyncWork(number1);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine($"Double square: {asyncWork}");
var squareTask = SquareAsync(number1);
Console.WriteLine($"SquareAsync1 of {number1}:{await squareTask}");
Console.WriteLine($"SquareAsync2 of {number1}:{SquareAsync(number1).Result}");
Console.WriteLine($"SquareAsync3 of {number1}:{SquareAsync(number1).GetAwaiter().GetResult()}");

void PrintOutput()
{
    Thread.Sleep(1000);
    Console.WriteLine("Some output");
}

async Task PrintOutputAsync()
{
    await Task.Delay(1000);
    Console.WriteLine("Some async output");
}

int Square(int n)
{
    return n * n;
}

async Task<int> DoSomeAsyncWork(int number)
{
    await Task.Delay(100);
    if (number < 5)
        throw new Exception($"Some exception with number {number}");
    return await SquareAsync(number);
}


async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    return n * n;
}

IEnumerable<int> GetInts(int n)
{
    for (int i = 0; i < n; i++)
    {
        yield return i;
    }
}

async IAsyncEnumerable<int> GetIntsAsync(int n)
{
    for (int i = 0; i < n; i++)
    {
        await Task.Delay(0);
        yield return i;
    }
}

public class SomeDataStorage
{
    private List<string> someData =
        new List<string> {"element1", "element2", "element3", "element4", "element5"};

    public async IAsyncEnumerable<string> GetElementAsync()
    {
        for (int i = 0; i < someData.Count; i++)
        {
            Console.WriteLine($"Get {i + 1} item");
            await Task.Delay(2000);
            yield return someData[i];
        }
    }

    public async Task SomeAsync()
    {
        Console.WriteLine("Test");
    }
}

static class ReflectionExt

{
    public static bool IsAsyncMethod(Type classType, string methodName)
    {
        // Obtain the method with the specified name.
        MethodInfo method = classType.GetMethod(methodName);

        Type attType = typeof(AsyncStateMachineAttribute);

        // Obtain the custom attribute for the method. 
        // The value returned contains the StateMachineType property. 
        // Null is returned if the attribute isn't present for the method. 
        var attrib = (AsyncStateMachineAttribute) method.GetCustomAttribute(attType);

        return (attrib != null);
    }
}