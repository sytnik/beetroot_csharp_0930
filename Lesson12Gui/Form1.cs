namespace Lesson12Gui;

public partial class Form1 : Form
{
    public List<ShortRecord> RecordList = new List<ShortRecord>();

    public sealed record ShortRecord(int Id = 100, string Name = "default");

    public Form1()
    {
        InitializeComponent();
        for (int i = 0; i < 100; i++)
            RecordList.Add(new ShortRecord(i + 1, $"element{i + 1}"));


        InitListbox(listBox1);

        // label1.Text = "12345";
    }

    private void InitListbox(ListBox lbBox)
    {
        lbBox.Items.Clear();
        for (int i = 0; i < RecordList.Count; i++)
            lbBox.Items.Add($"{RecordList[i].Id} - {RecordList[i].Name}");
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listbox = sender as ListBox;
        var item = listbox.SelectedItem.ToString();
        var result = MessageBox.Show($"User selected:{item}", "Delete item?",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        if (result == DialogResult.OK)
        {
            var itemId = int.Parse(item.Split(" ")[0]);
            var foundItem = RecordList.First(rec => rec.Id == itemId);
            RecordList.Remove(foundItem);
            InitListbox(listBox1);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        button1.Text = textBox1.Text;

        try
        {
            throw new Exception("exception occured");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Error!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}