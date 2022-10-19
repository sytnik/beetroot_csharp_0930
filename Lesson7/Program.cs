Console.WriteLine(SomeCode7.Compare("", ""));
Console.WriteLine(SomeCode7.GlobalString);
var myNonStaticOne = new MyNonStaticOne();
myNonStaticOne.Str2 = "24";
var myNonStaticOne2 = new MyNonStaticOne();
myNonStaticOne2.Str2 = "34";
var str = "123r";
var integer = 5;
int.TryParse(str, out integer);
var chararray = str.ToCharArray();
var charlist = str.ToList();

Console.WriteLine(SomeCode7.Compare("", "") ? "if is true" : "if is false");
Console.WriteLine(SomeCode7.Compare("123", "123"));
Console.WriteLine(SomeCode7.Compare("321", "123"));
Console.WriteLine(SomeCode7.Compare("355", "5125125"));
var chars1 = new[] {'A', 'b', '¼', '+', '2', '\u1234', (char) 0x41};

foreach (var ch in chars1)
{
    Console.WriteLine($"Symbol: {ch}");
    Console.WriteLine($"IsLower: {char.IsLower(ch)}");
    Console.WriteLine($"IsUpper: {char.IsUpper(ch)}");
    Console.WriteLine($"IsNumber: {char.IsNumber(ch)}");
    Console.WriteLine($"IsSymbol: {char.IsSymbol(ch)}");
    Console.WriteLine($"IsLetter: {char.IsLetter(ch)}");
    Console.WriteLine($"IsDigit: {char.IsDigit(ch)}");
    Console.WriteLine($"ToLower: {char.ToLower(ch)}");
    Console.WriteLine($"ToUpper: {char.ToUpper(ch)}");
}


var interpolatedstr = $"str {str} ,-\"- {integer}";
Console.WriteLine(interpolatedstr);
var concatstr = "123" + " 124" + "21124 " + str + " " + integer;
string formatted = "Format: {4}, {1}, {3}";
Console.WriteLine("Format: {4}, {1}, {3}", 0, 1, 2, 3, null);
string str3 = "Making a substring";
Console.WriteLine(str3[0]);
Console.WriteLine(str3[3..5]);
Console.WriteLine(str3[..10]);
Console.WriteLine(str3[5..]);
string str1 = "TeSt";
string str2 = "tesT";
Console.WriteLine("string comparison");
Console.WriteLine(str1 == str2);
Console.WriteLine(str1.Equals(str2));
Console.WriteLine(str1.ToUpper() == str2.ToUpper());
Console.WriteLine(str1.ToLower() == str2.ToLower());
Console.WriteLine(str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
Console.WriteLine(str1.CompareTo("1313"));
Console.WriteLine(str1.CompareTo(str2));
Console.WriteLine(str1.CompareTo(null));
var test = str1.Contains('t');
var tes2t = str1.Contains("te", StringComparison.OrdinalIgnoreCase);
var str5 = "string-index-string";
Console.WriteLine(str5);
Console.WriteLine(str5.IndexOfAny(new[] {'e', 'j', 'n'}));
Console.WriteLine(str5.IndexOf("242"));
var strremove = str5.Remove(10);
var strremove2 = str5.Remove(9, 5);
var strreplace = str5.Replace('s', 'x');
var strreplace2 = str5.Replace("rin", "");
var split = str5.Split(' ');
var split2 = str5.Split("-");
var chars = new[] {'s', 't', 'r'};
var str7 = chars.ToString();
Console.WriteLine(strremove);
var orderedstr = string.Join(",", str5.OrderBy(s => s));
var orderedstrdesc = string.Join(",", str5.OrderByDescending(s => s));
Console.WriteLine(orderedstr);

var tuplelist = new List<(int Id, string Name)>
{
    (2, "Name1"),
    (3, "Name3"),
    (1, "Name2")
};
var tuplelist1 = tuplelist.OrderBy(tuple => tuple.Id).ToList();
var tuplelist2 = tuplelist.OrderByDescending(tuple => tuple.Name).ToList();
str1 = "This is a string";

public class MyNonStaticOne
{
    public string Str2 = "123";

    public void WriteVar()
    {
        Console.WriteLine(Str2);
    }

    public void ReadVar()
    {
        Str2 = Console.ReadLine();
    }
}

// todo hw samples
public static class SomeCode7
{
    public static string GlobalString = "myglobalstring";

    public static bool Compare(string first, string second)
    {
        if (first.Length != second.Length) return false;
        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i]) return false;
        }

        return true;
    }

    public static void Analyze()
    {
    }

    public static string Sort(string source)
    {
        return "";
    }

    public static string Duplicate(string source)
    {
        return "";
    }
}