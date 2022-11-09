using System.Collections;

IEnumerable<int> power = Power(5, 10);
var elementsInRange = power.Where(x => x > 10 && x < 10000);

var ngStack = new Stack();
var stack = new Stack<SomeRecord>();
stack.Push(null);
stack.Push(new SomeRecord(Guid.NewGuid()));
stack.Push(new SomeRecord(Guid.NewGuid()));
var elem = stack.Pop();
ngStack.Push(null);
ngStack.Push("123");
ngStack.Push(new SomeRecord(Guid.NewGuid()));
Console.WriteLine(ngStack.Pop());
Console.WriteLine(ngStack.Pop());
Console.WriteLine(ngStack.Pop());
Console.WriteLine("Hello, World!");

var queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());

var arrayList = new ArrayList();
arrayList.Add(1);
arrayList.Add("123");
arrayList.Add(null);

var dict = new Dictionary<SomeEnum, SomeRecord>();
var someGuid = Guid.NewGuid();
var someElem = new SomeRecord(someGuid, "123");
dict.Add(SomeEnum.ElemOne, someElem);
dict.Add(SomeEnum.ElemTwo, new SomeRecord(Guid.NewGuid(), "123"));
var key = dict.ContainsKey(SomeEnum.ElemTwo);
var value = dict.ContainsValue(someElem);
var guid = new Guid();
guid = Guid.Empty;
guid = Guid.NewGuid();

IEnumerable<SomeRecord> records = new[]
{
    new SomeRecord(Guid.NewGuid(), "111"),
    new SomeRecord(Guid.NewGuid(), "222"),
    new SomeRecord(Guid.NewGuid(), "333"),
};


var list = new List<SomeRecord>();
list.AddRange(records);
list.Clear();
list.Add(records.ElementAt(2));
list.Add(records.ElementAtOrDefault(10));
list = null;
list = new List<SomeRecord>();
list.Add(records.Last());

var sortInList = list.Order().ToList();
var sortedList = new SortedList<int?, string>();
sortedList.Add(1, "123");
sortedList.Add(-1, "124");
sortedList.Add(6, "127");
var first = sortedList.First();

var set = new HashSet<object>();
foreach (var el in records)
{
    set.Add(el);
}
set.Add(2);
set.Add("123");
set.Add("123");
set.Add(2);


var second = sortedList.First();
foreach (var s in sortedList)
{
    Console.WriteLine(s);
}



static IEnumerable<int> Power(int number, int exponent)
{
    var result = 1;
    for (var i = 0; i < exponent; i++)
    {
        result *= number;
        yield return result;
    }
}

public record SomeRecord(Guid Id, string Name = "");

enum SomeEnum
{
    ElemOne,
    ElemTwo
}