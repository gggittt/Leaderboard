
[System.Serializable]
public class HighScoreRecord
{
    public string Name { get; }
    public float Score { get; }
    public int Index { get; set; }

    public HighScoreRecord(string name, float score)
    {
        Name = name;
        Score = score;
        Index = int.MaxValue;
    }
}