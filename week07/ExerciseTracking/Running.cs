using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, double minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // mph = (distance / minutes) * 60
        return (_distanceMiles / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        // minutes per mile = minutes / distance
        return Minutes / _distanceMiles;
    }
}

