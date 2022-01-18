using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderEditor : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_InputField _scoreInput;
    [SerializeField] private Leaderboard _leaderboard;
    
    
    public void EditLeader()
    {
        int.TryParse(_scoreInput.text, out int score);
        
        _leaderboard.EditLeader(_nameInput.text, score);
    }
    

}


