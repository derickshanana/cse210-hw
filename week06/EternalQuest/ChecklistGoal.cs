// ChecklistGoal.cs
class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int targetCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int timesCompleted = 0)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        this.timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (timesCompleted < targetCount)
        {
            timesCompleted++;
            return points + (timesCompleted == targetCount ? bonusPoints : 0);
        }
        return 0;
    }

    public override bool IsComplete() => timesCompleted >= targetCount;

    public override string GetStatus() => $"[{(IsComplete() ? "X" : " ")}] {name} - {description} ({timesCompleted}/{targetCount})";

    public override string GetSaveString() => $"ChecklistGoal:{name},{description},{points},{targetCount},{bonusPoints},{timesCompleted}";
}