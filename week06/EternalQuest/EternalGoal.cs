public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string id, string title, int pointsPerEvent)
        : base(id, title, pointsPerEvent)
    {
        _timesRecorded = 0;
    }

    // Used by loading from file.
    private EternalGoal(string id, string title, int pointsPerEvent, int timesRecorded)
        : base(id, title, pointsPerEvent)
    {
        _timesRecorded = timesRecorded;
    }

    public int TimesRecorded => _timesRecorded;

    // Eternal goals never complete.
    public override bool IsComplete => false;

    public override string GetStatusLine()
    {
        // Example: (Eternal) [ ] Read scriptures (0 recorded)
        return $"(Eternal) [ ] {Title} (recorded {_timesRecorded} times)";
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return PointsPerEvent;
    }

    public override string GetSaveLine()
    {
        // Type:Eternal|id|title|pointsPerEvent|timesRecorded
        return $"Eternal|{Id}|{Title}|{PointsPerEvent}|{_timesRecorded}";
    }

    public static EternalGoal FromSave(string[] parts)
    {
        // parts[0]=Eternal
        string id = parts[1];
        string title = parts[2];
        int pointsPerEvent = int.Parse(parts[3]);
        int timesRecorded = int.Parse(parts[4]);
        return new EternalGoal(id, title, pointsPerEvent, timesRecorded);
    }
}

