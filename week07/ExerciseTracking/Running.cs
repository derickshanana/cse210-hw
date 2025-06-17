// File: Running.cs
public class Running : Activity
{
    private double _distanceKm;

    public Running(string date, int minutes, double distanceKm)
        : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;

    public override double GetSpeed() => (_distanceKm / GetLengthMinutes()) * 60;

    public override double GetPace() => GetLengthMinutes() / _distanceKm;
}