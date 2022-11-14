using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17;

public class TestClass
{
    public DateTime SomeDate = DateTime.Now;

    public void Method1()
    {
        var format = "dddd, dd MMMM yyyy HH:mm:ss";
        // var formattedDate1 = Lesson17.DateTimeExtensions.FormatDate(SomeDate, "dddd, dd MMMM yyyy HH:mm:ss");
        var formattedDate1 = SomeDate.FormatDate(format);
        var formattedDate2 = format.FormatDate(SomeDate);
        OutputData($"Case 1: {formattedDate1}");

        var numericList = new List<int> {1, 2, 3};
        var resultstring = numericList.OutputCollection();
        var someNestedList = new List<(int, int, string)> {(1, 2, "elem1")};
        resultstring = numericList.OutputCollection();
    }

    public void Method2()
    {
        var formattedDate2 = SomeDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");
        Console.WriteLine($"Case 1: {formattedDate2}");
    }

    public void OutputData(string data) => Console.WriteLine(data);
}


internal static class DateTimeExtensions
{
    public static string FormatDate(this DateTime date, string format)
        => date.ToString(format);

    public static string FormatDate(this string format, DateTime date)
        => date.ToString(format);

    public static string FormatDate(this object date, string format)
        => date.ToString();

    public static string OutputCollection<T>(this IEnumerable<T> enumerable)
        => string.Join(" <=> ", enumerable);
}