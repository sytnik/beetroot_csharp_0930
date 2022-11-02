var parking = new Parking(new List<Transport>
{
    new Car("Toyota", 2, 4, true),
    new Bike("Hyndai", 2, 2, false)
});
var allcars = parking.Transports
    .Where(transport => transport is Car car && car.HasAirbags);
var prop = allcars.First();

var parameters1 = parking.Transports[0].OutputParams();
var parameters2 = parking.Transports[1].OutputParamsExt(DateTime.Now);
var firstHasAirbags = DoesTransportHaveAirbags(parking.Transports[0]);
var secondHasAirbags = DoesTransportHaveAirbags(parking.Transports[1]);
TransportStartEngine(parking.Transports[0]);
TransportStartEngine(parking.Transports[1]);
int value = 40;
var isEven = value.IsEven();
Console.ReadLine();

bool DoesTransportHaveAirbags(object transport)
{
    return transport is Car car ? car.HasAirbags : false;
}

void TransportStartEngine(object transport)
{
    var iHasEngine = transport as IHasEngine;
    iHasEngine?.EngineStart();
}

public static class DigitsExtensions
{
    public static bool IsEven(this int number) => number % 2 == 0;
}

public static class TransportExtensions
{
    public static string OutputParamsExt(this Transport transport, DateTime time)
        => $"{transport.Name} - engine of {transport.EngineSize} and {transport.WheelCount} wheels, data requested at {time}";
}


public class Parking
{
    public List<Transport> Transports { get; set; }

    public Parking(List<Transport> transports)
    {
        Transports = transports;
    }
}


public interface IHasWheels
{
    public int WheelCount { get; set; }
}

public interface IHasEngine
{
    public int SoundLoudness { get; set; }
    private static string Vendor { get; set; }
    public int EngineSize { get; set; }

    public void EngineStart();
}

public abstract class Transport : IHasWheels
{
    private static string Manufacturer { get; set; }
    public int SoundLoudness { get; set; }
    public string Name { get; set; }
    public int EngineSize { get; set; }
    public int WheelCount { get; set; }

    protected Transport()
    {
    }

    protected Transport(string name, int engineSize, int wheelCount)
    {
        Name = name;
        EngineSize = engineSize;
        WheelCount = wheelCount;
    }

    public abstract void Move();

    public void Stop() => Console.WriteLine("Transport Stop");

    public string OutputParams()
        => $"{Name} - engine of {EngineSize} and {WheelCount} wheels";
}


internal class Car : Transport, IHasEngine
{
    public bool HasAirbags { get; set; }

    public void EngineStart() => Console.WriteLine("car EngineStart");

    public override void Move() => Console.WriteLine("car is moving");

    public void Stop() => Console.WriteLine("car is stopping");

    public Car(string name, int engineSize, int wheelCount, bool hasAirbags)
        : base(name, engineSize, wheelCount)
        => HasAirbags = hasAirbags;
}

internal class Bike : Transport, IHasEngine
{
    public bool IsVintage { get; set; }

    public void EngineStart() => Console.WriteLine("Bike EngineStart");

    public override void Move() => Console.WriteLine("Bike is moving");

    public void Stop() => Console.WriteLine("Bike is stopping");

    public Bike()
    {
    }

    public Bike(string name, int engineSize, int wheelCount, bool isVintage)
        : base(name, engineSize, wheelCount)
        => IsVintage = isVintage;
}