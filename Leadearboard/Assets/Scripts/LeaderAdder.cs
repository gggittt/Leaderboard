using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LeaderAdder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  _nameText;
    [SerializeField] private TextMeshProUGUI  _scoreTmpText;
    //[SerializeField] private InputField  _scoreInput;
    [SerializeField] private Text  _scoreText;
    
    [SerializeField] private Leaderboard _leaderboard;

    
    public void AddNewLeader()
    {
        string scoreText = _scoreText.text;
        Debug.Log($"<color=cyan> {scoreText}  </color>");
        //scoreText = scoreText.Trim();
        //Debug.Log($"<color=cyan> {newScore}  </color>");

        var isParsed = float.TryParse(scoreText, out float score);

        
        
        //var score = Convert.ToInt32(textScore);

        //Debug.Log($"<color=cyan> isParsed = {isParsed}  </color>");
        Debug.Log($"<color=cyan> {scoreText} = {score}  </color>");
        Debug.Log($"<color=cyan> name = {_nameText.text}  </color>");

        LogText();

        if (true)
        {
            var newLeader = new Leader(_nameText.text, score);
            _leaderboard.AddLeader(newLeader);
        }
        else
        {
            Debug.Log($"<color=cyan> Score insert incorrectly!  </color>");
        }
    }

    private void LogText()
    {
        int.TryParse(_scoreTmpText.text, out int a);
        Debug.Log($"<color=cyan> int.TryParse ру англ  {a}  </color>");
        
        
        Debug.Log($"<color=green> {_nameText.text}  </color>");
        Debug.Log($"<color=green> {_scoreText.text}  </color>");
    }
}