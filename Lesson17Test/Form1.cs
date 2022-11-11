namespace Lesson17Test;

public partial class Form1 : Form
{
    private EventHandler showEventHandler;

    public Form1()
    {
        InitializeComponent();
        showEventHandler = delegate
        {
            UpdateText();
        };
        button1.Click += showEventHandler;
        button1.Click += delegate
        {
            ShowSomeMessage();
        };
        // button1.Click -= showEventHandler;
    }

    private static void ShowSomeMessage()
    {
        MessageBox.Show("user has clicked a button!", "event raised");
    }

    private void UpdateText()
    {
        button1.Text = "some new text";
    }

    private void button1_Click(object sender, EventArgs e)
    {
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