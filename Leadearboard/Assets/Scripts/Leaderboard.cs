using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<Leader> Leaders { get; } = new List<Leader>();

    [SerializeField] private LeaderDrawer _drawer;
    //[SerializeField] private LeaderEditor _editor;
    

    public void AddLeader(string leaderName, int score)
    {
        Leaders.Add(new Leader(leaderName, score));
        _drawer.Draw(leaderName, score);
    }

    public void EditLeader(string nameInputText, int result)
    {
        //_editor.EditLeader(nameInputText, result);
        
    }
}


