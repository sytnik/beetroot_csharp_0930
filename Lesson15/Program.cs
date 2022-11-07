var newList = new CustomList<int>();
var size = newList.Count;
newList.AddElement(1);
newList.AddElement(2);
newList.AddElement(2);
newList.AddElement(3);
newList.AddElement(4);

newList.AddBatchElements(new []{1,2,3,4});
newList.RemoveElement(4);
newList.RemoveByIndex(4);



Console.WriteLine("Hello, World!");
var list = new List<SomeBaseType>
{
    new OtherType1
    {
        Id = 1,
        Name = "123",
        UniqueId = Guid.NewGuid()
    },
    new OtherType2
    {
        Id = 2,
        Name = "234",
        Text = "text"
    },
    new()
    {
        Id = 3,
        Name = "688"
    }
};

foreach (var elem in list)
{
    Console.WriteLine(OutputElement(elem));
}

string OutputElement(SomeBaseType value)
{
    string prop = "";
    var elem = value as OtherType1;
    if (elem != null) prop = $"{elem.UniqueId}";
    else if (value is OtherType2 type2) prop = type2.Text;
    else if (value is not OtherType1 &&
             value is not OtherType2 &&
             value is SomeBaseType) prop = "no extra properties";
    return $"{value.Id} - {value.Name} - {prop}";
}

public class SomeBaseType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class OtherType1 : SomeBaseType
{
    public Guid UniqueId { get; set; }
}

public class OtherType2 : SomeBaseType
{
    public string Text { get; set; }
}