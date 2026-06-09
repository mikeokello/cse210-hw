public static class GoalFactory
{
    public static Goal CreateFromSaveLine(string line)
    {
        // Expected format (pipe-delimited):
        // Simple|id|title|pointsPerEvent|completed
        // Eternal|id|title|pointsPerEvent|timesRecorded
        // Checklist|id|title|pointsPerEvent|targetCount|completedCount
        string[] parts = line.Split('|');
        if (parts.Length == 0)
        {
            throw new System.Exception("Invalid save line.");
        }

        string type = parts[0];

        return type switch
        {
            "Simple" => SimpleGoal.FromSave(parts),
            "Eternal" => EternalGoal.FromSave(parts),
            "Checklist" => ChecklistGoal.FromSave(parts),
            _ => throw new System.Exception($"Unknown goal type '{type}'."),
        };
    }
}

