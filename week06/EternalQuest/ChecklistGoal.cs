public class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;

    public ChecklistGoal(string id, string title, int pointsPerEvent, int targetCount)
        : base(id, title, pointsPerEvent)
    {
        _completedCount = 0;
        _targetCount = targetCount;
    }

    // Used by loading from file.
    private ChecklistGoal(string id, string title, int pointsPerEvent, int targetCount, int completedCount)
        : base(id, title, pointsPerEvent)
    {
        _targetCount = targetCount;
        _completedCount = completedCount;
    }

    public int CompletedCount => _completedCount;
    public int TargetCount => _targetCount;

    public override bool IsComplete => _completedCount >= _targetCount;

    public int GetBonusPointsOnCompletion()
    {
        // Bonus of targetCount * pointsPerEvent (common BYU-I spec style)
        return _targetCount * PointsPerEvent;
    }

    public override string GetStatusLine()
    {
        string check = IsComplete ? "[X]" : "[ ]";
        return $"{check} {Title} - Completed {_completedCount}/{_targetCount} times";
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _completedCount++;

        int points = PointsPerEvent;
        if (IsComplete)
        {
            points += GetBonusPointsOnCompletion();
        }

        return points;
    }

    public override string GetSaveLine()
    {
        // Type:Checklist|id|title|pointsPerEvent|targetCount|completedCount
        return $"Checklist|{Id}|{Title}|{PointsPerEvent}|{_targetCount}|{_completedCount}";
    }

    public static ChecklistGoal FromSave(string[] parts)
    {
        // parts[0]=Checklist
        string id = parts[1];
        string title = parts[2];
        int pointsPerEvent = int.Parse(parts[3]);
        int targetCount = int.Parse(parts[4]);
        int completedCount = int.Parse(parts[5]);
        return new ChecklistGoal(id, title, pointsPerEvent, targetCount, completedCount);
    }
}

