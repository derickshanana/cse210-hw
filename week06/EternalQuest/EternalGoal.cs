//
//EternalGoal.cs
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => points;

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[∞] {name} - {description}";

    public override string GetSaveString() => $"EternalGoal:{name},{description},{points}";
}