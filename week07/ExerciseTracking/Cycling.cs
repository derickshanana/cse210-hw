// File: Cycling.cs
public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(string date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetSpeed() => _speedKph;

    public override double GetDistance() => (_speedKph * GetLengthMinutes()) / 60;

    public override double GetPace() => 60 / _speedKph;
}
