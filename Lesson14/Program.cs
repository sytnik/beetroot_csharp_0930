using Lesson14;

var vector1 = new Vector(1, 2);
var vector2 = new Vector(8, 6);
var vector3 = new Vector(8, 6);
double length = vector3.GetLength();
length = vector3;
int length2 = (int) vector3;
var newvector = vector1 + vector2;
var getX = newvector[Dimension.X];
newvector[Dimension.Y] = 15;

var equals1 = vector1.Equals(vector2);
var equalsOp = vector1 == vector2;
var equals2 = vector2.Equals((object) vector3);

var charArray = new[] {'r', 'n', 'x', 'y'};
var doubleList = new List<double> {1.34, 4, 23.56};
var enumerable = doubleList as IEnumerable<double>;
var tupleList = new List<(double, double)>
    {(1.34, 1.2424), (4, 251252512), (23.56, 3523532)};
var recordList = new List<Rec>
    {new(1.34, 1.2424), new(4, 251252512), new(23.56, 3523532)};
Console.WriteLine(charArray.GetFormattedStringFromList());
Console.WriteLine(doubleList.GetFormattedStringFromList());
Console.WriteLine(tupleList.GetFormattedStringFromList());
Console.WriteLine(recordList.GetFormattedStringFromList());

public record Rec(double v1, double v2);