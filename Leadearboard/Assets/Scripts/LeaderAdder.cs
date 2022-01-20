using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityRandom = UnityEngine.Random;


public class LeaderAdder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Text _scoreText;

    [SerializeField] private Leaderboard _leaderboard;


    public void AddNewLeader()
    {
        HighScoreRecord newRecord = InputInfoGetter.TryGetInputsInfo(out bool isSuccess, _nameText.text, _scoreText.text);

        if (isSuccess == false)
            return;
        
        _leaderboard.AddLeaderRecord(newRecord);
    }


    public void FillBySample()
    {
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Nikolay Dybowski",
            UnityRandom.Range(1, 999)));
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Mikhail Shkredov", UnityRandom.Range(50, 700)));
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Hideo Kojima", UnityRandom.Range(1, 322)));
    }
}