using System;

public class Swimming : Activity
{
    private double _laps;

    public Swimming(DateTime date, double minutes, double laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // distance(km) = laps * 50 / 1000
        // distance(miles) = km * 0.62
        double distanceKm = _laps * 50.0 / 1000.0;
        return distanceKm * 0.62;
    }

    public override double GetSpeed()
    {
        // mph = (distance / minutes) * 60
        double distanceMiles = GetDistance();
        return (distanceMiles / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        // minutes per mile = minutes / distance
        return Minutes / GetDistance();
    }
}



