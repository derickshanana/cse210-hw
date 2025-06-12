// NegativeGoal.cs
class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, -Math.Abs(penalty)) { }

    public override int RecordEvent() => points; // negative value

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[!] {name} - {description} (Penalty: {-points} points)";

    public override string GetSaveString() => $"NegativeGoal:{name},{description},{-points}";
}