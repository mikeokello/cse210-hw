public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string id, string title, int pointsPerEvent)
        : base(id, title, pointsPerEvent)
    {
        _completed = false;
    }

    // Used by loading from file.
    private SimpleGoal(string id, string title, int pointsPerEvent, bool completed)
        : base(id, title, pointsPerEvent)
    {
        _completed = completed;
    }

    public override bool IsComplete => _completed;

    public override string GetStatusLine()
    {
        string check = _completed ? "[X]" : "[ ]";
        return $"{check} {Title}";
    }

    public override int RecordEvent()
    {
        if (_completed)
        {
            return 0;
        }

        _completed = true;
        return PointsPerEvent;
    }

    public override string GetSaveLine()
    {
        // Type:Simple|id|title|pointsPerEvent|completed
        return $"Simple|{Id}|{Title}|{PointsPerEvent}|{_completed}";
    }

    public static SimpleGoal FromSave(string[] parts)
    {
        // parts[0]=Simple
        string id = parts[1];
        string title = parts[2];
        int pointsPerEvent = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);
        return new SimpleGoal(id, title, pointsPerEvent, completed);
    }
}

