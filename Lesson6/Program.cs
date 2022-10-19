internal class Program
{
    static int myvariable = 5;

    enum SortAlgorithmType
    {
        BubbleSorting,
        SelectionSorting,
        InsertionSorting
    }

    static int[] Sort(int[] arrayToSort, SortAlgorithmType type)
    {
        switch (type)
        {
            case SortAlgorithmType.BubbleSorting:
                return BubbleSorting(arrayToSort);
                break;
            case SortAlgorithmType.SelectionSorting:
                return BubbleSorting(arrayToSort);
                break;
            case SortAlgorithmType.InsertionSorting:
                return BubbleSorting(arrayToSort);
                break;
        }

        return null;
    }

    private static void Main(string[] args)
    {
        List<(int Id, string Name, double Quantity)> list = new List<(int Id, string Name, double Quantity)>();
        list.Add((1, "str", 4.5));
        var test1 = (Id1: 1, CustomInt2: 2, Name: "str", DoubleVal: 4.5);
        test1.Item1 = 1;
        test1.CustomInt2 = 2;
        (int Id, string Name, double Quantity) test2 = (1, "str", 4.5);
        test2.Id = 1;

        var arr = new (int Id, string Name)[3][];
        arr[0] = new[] {(1, "elem01"), (2, "elem02"), (3, "elem03")};
        arr[1] = new[] {(4, "elem04"), (5, "elem05")};
        arr[2] = new[] {(6, "elem06")};
        foreach (var subarr in arr)
        {
            Console.Write(string.Join(" *  ", subarr));
            Console.Write(subarr.ToString());
            Console.Write(Environment.NewLine);
            foreach (var elem in subarr)
            {
                Console.Write(elem + "   ");
            }

            Console.Write(Environment.NewLine);
        }


        var arr2 = new (int Id, string Name)[2, 2];
        arr2[0, 0] = (1, "elem00");
        arr2[0, 1] = (2, "elem01");
        arr2[1, 0] = (3, "elem10");
        arr2[1, 1] = (4, "elem11");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(++arr2[i, j].Id + "   ");
            }

            Console.Write(Environment.NewLine);
        }


        var elements = new[] {1, 2, 4, 5};
        elements = elements.OrderByDescending(i => i).ToArray();
        Console.WriteLine((int) SortAlgorithmType.InsertionSorting);
        Console.WriteLine(SortAlgorithmType.BubbleSorting);
        Console.WriteLine(SortAlgorithmType.SelectionSorting);
        myvariable = 10;
        int var2 = 5;

        var result = testMethod(var2);
        result = testMethod(myvariable);
        int arrayValue = 0;
        int[] myArray = InputArray();
        var resultArray = Sort(myArray, SortAlgorithmType.BubbleSorting);
        var resultArray1 = Sort(myArray, SortAlgorithmType.SelectionSorting);
        var resultArray2 = Sort(myArray, SortAlgorithmType.InsertionSorting);
        BubbleSorting(myArray);
        SelectionSorting();
        var strresult = $"result:{testMethod(5)}";
        Console.WriteLine($"result:{testMethod(5)}");
    }

    public static int testMethod(int val)
    {
        myvariable = 5;
        return val * val;
    }

    static int[] BubbleSorting(int[] myArray)
    {
        int arrayValue = 0;
        Console.WriteLine("\n Sorting array with bubble method  : ");
        Console.WriteLine($"////////////////////////////////////////");
        Console.WriteLine();


        for (int i = 0; i < myArray.Length; i++)
        {
            for (int j = 0; j < myArray.Length - 1; j++)
            {
                if (myArray[j] > myArray[i] + 1)
                {
                    arrayValue = myArray[j];
                    myArray[j] = myArray[j + 1];
                    myArray[j + 1] = arrayValue;
                }
            }
        }

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine(myArray[i]);
        }

        Console.WriteLine();
        Console.WriteLine($"////////////////////////////////////////");
        return myArray;
    }

    static int[] InputArray()
    {
        Console.Write($"Enter number of values in array: \t");

        int elements = int.Parse(Console.ReadLine());
        int[] myArray = new int[elements];


        for (int i = 0; i < elements; i++)
        {
            Console.Write($"Enter element of array number {i + 1}: \t");
            myArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\n You're entered next array  : ");
        Console.WriteLine($"////////////////////////////////////////");
        Console.WriteLine();

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine(myArray[i]);
        }

        Console.WriteLine();
        Console.WriteLine($"////////////////////////////////////////");
        return myArray;
    }


    static int[] SelectionSorting()
    {
        int[] myArray = InputArray();
        int arrayValue = 0;
        Console.WriteLine("\n Sorting array with selection method  : ");
        Console.WriteLine($"////////////////////////////////////////");
        Console.WriteLine();


        for (int i = 0; i < myArray.Length; i++)
        {
            for (int j = 0; j < myArray.Length - 1; j++)
            {
                if (myArray[j] > myArray[i] + 1)
                {
                    arrayValue = myArray[j];
                    myArray[j] = myArray[j + 1];
                    myArray[j + 1] = arrayValue;
                }
            }
        }

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.WriteLine(myArray[i]);
        }

        Console.WriteLine();
        Console.WriteLine($"////////////////////////////////////////");
        return myArray;
    }
}


public class TestClass
{
    int MyVar = 1;

    public void SomeMethod()
    {
        MyVar = 2;
    }
}