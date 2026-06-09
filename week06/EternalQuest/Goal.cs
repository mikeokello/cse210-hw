using System;

public abstract class Goal
{
    private string _id;
    private string _title;
    private int _pointsPerEvent;

    protected Goal(string id, string title, int pointsPerEvent)
    {
        _id = id;
        _title = title;
        _pointsPerEvent = pointsPerEvent;
    }

    public string Id => _id;
    public string Title => _title;
    public int PointsPerEvent => _pointsPerEvent;

    // Returns the formatted list line for the goal.
    public abstract string GetStatusLine();

    // True if the goal is complete (simple/checklist). Eternal goals return false.
    public abstract bool IsComplete { get; }

    // Called when user records an event for this goal.
    // Returns the number of points earned.
    public abstract int RecordEvent();

    // Returns a string that can be saved and later loaded.
    public abstract string GetSaveLine();
}

