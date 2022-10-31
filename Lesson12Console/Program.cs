var times = new List<SomeEntity>()
{
    new SomeEntity("lesson1", TimeOnly.FromDateTime(DateTime.Now.AddHours(-5))),
    new SomeEntity("lesson1", TimeOnly.FromDateTime(DateTime.Now))
};


var areEqual = times[0].Equals(times[1]);
var areEqual2 = times[0] == times[1];
var time = times[0].OutputTime();


var fullRecord = new FullRecord();
fullRecord.Id = 1;
fullRecord.Name = "setProp";

var shortRecord = new ShortRecord(1);
var shortRecord2 = new ShortRecord(1, "secondname");
shortRecord2 = shortRecord2 with {Id = 5, Name = "newname"};

foreach (var entity in times)
    Console.WriteLine(entity);

public record FullRecord
{
    public int Id { get; set; } = 100;
    public string Name { get; set; } = "default";

    public FullRecord()
    {
    }
}

public sealed record ShortRecord(int Id = 100, string Name = "default");


public class BaseEntity
{
    public string Id;

    public TimeOnly SomeTime { get; set; }

    public virtual string OutputTime() =>
        SomeTime.ToString("HH");
}


public class SomeEntity : BaseEntity
{
    public string Name { get; set; }

    public SomeEntity(string name, TimeOnly time)
    {
        Name = name;
        SomeTime = time;
    }

    public override bool Equals(object? obj) =>
        Name == (obj as SomeEntity)?.Name;

    public override string ToString() =>
        $"{Name} - {SomeTime:HH:mm}";

    public override string OutputTime() =>
        SomeTime.ToString("HH:mm");
}