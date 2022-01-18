using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<Leader> Leaders { get; } = new List<Leader>();
    
    //[SerializeField] private LeaderEditor _editor;
    
    [SerializeField] private Transform _stringBox;
    [SerializeField] private UiLeaderString _stringPrefab;

    public void AddLeader(Leader leader)
    {
        Leaders.Add(leader);
        UiLeaderString uiString = Instantiate(_stringPrefab, _stringBox);
        uiString.OnDestroy += StringDeleteHandler;
        uiString.SetInfo(leader);
    }
    
    private void StringDeleteHandler(Leader sender)
    {
        Leaders.Remove(sender);
    }

    public void EditLeader(string nameInputText, int result)
    {
        //_editor.EditLeader(nameInputText, result);
        
    }
}


