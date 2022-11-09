namespace Lesson17Test;

public partial class Form1 : Form
{
    public List<SomeData> DataList;

    public Form1()
    {
        InitializeComponent();
        button1.Click += delegate { NewMethod(); };
    }

    //private void button1_Click(object sender, EventArgs e)
    //{
    //    NewMethod();
    //}

    private void NewMethod()
    {
        DataList = SomeExtensions.Seed(100000).ToList();
        DataList.Clear();
        DataList = null;
        GC.Collect(0, GCCollectionMode.Forced, true, true);
        GC.Collect(0, GCCollectionMode.Forced, true, true);
        GC.Collect(0, GCCollectionMode.Forced, true, true);
    }
}

public class SomeData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Data { get; set; }

    public SomeData(int id, string name, string data)
    {
        Id = id;
        Name = name;
        Data = data;
    }
};

public static class SomeExtensions
{
    public static IEnumerable<SomeData> Seed(int count)
    {
        for (int i = 1; i < count; i++)
        {
            yield return new SomeData(i, $"somename{i}", $"somedata{i}");
        }
    }

    public static List<SomeData> Seed2(int count)
    {
        var temp = new List<SomeData>();
        for (int i = 1; i < count; i++)
        {
            temp.Add(new SomeData(i, $"somename{i}", $"somedata{i}"));
        }

        return temp;
    }
}