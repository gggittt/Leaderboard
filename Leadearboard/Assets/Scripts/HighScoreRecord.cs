public class HighScoreRecord
{
    public string Name { get; }
    public int Score { get; }
    public int Index { get; set; }

    public HighScoreRecord(string name, int score)
    {
        Name = name;
        Score = score;
        Index = int.MaxValue;
    }
}