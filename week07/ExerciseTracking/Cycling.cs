using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, double minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetDistance()
    {
        // distance (miles) = speed (mph) * hours
        double hours = Minutes / 60.0;
        return _speedMph * hours;
    }

    public override double GetPace()
    {
        // pace = 60 / speed
        return 60.0 / _speedMph;
    }
}

