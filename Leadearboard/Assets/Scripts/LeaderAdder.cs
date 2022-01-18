using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityRandom = UnityEngine.Random;


public class LeaderAdder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;

    [SerializeField] private TextMeshProUGUI _scoreTmpText;

    //[SerializeField] private InputField  _scoreInput;
    [SerializeField] private Text _scoreText;

    [SerializeField] private Leaderboard _leaderboard;


    public void AddNewLeader()
    {
        var isScoreParsed = float.TryParse(_scoreText.text, out float score);
        string newName = _nameText.text;

        if (newName == String.Empty)
        {
            Debug.Log($"<color=cyan> Name can't be empty!  </color>");
            return;
        }

        if (isScoreParsed == false)
        {
            Debug.Log($"<color=cyan> Score insert incorrectly! </color>");
            return;
        }
        
        var highScore = new HighScoreRecord(newName, score);
        _leaderboard.AddLeaderRecord(highScore);
    }

    public void FillBySample()
    {
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Nikolay Dybowski", 
            UnityRandom.Range(1,999)));
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Mikhail Shkredov", UnityRandom.Range(50,700)));
        _leaderboard.AddLeaderRecord(new HighScoreRecord("Hideo Kojima", UnityRandom.Range(1,322)));

    }
    
}