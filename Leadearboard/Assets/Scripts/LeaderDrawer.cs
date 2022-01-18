using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderDrawer : MonoBehaviour
{
    [SerializeField] private Transform _stringBox;
    [SerializeField] private UiLeaderString _stringPrefab;


    public UiLeaderString Draw(string leaderName, int score)
    {
        var uiString = Instantiate(_stringPrefab, _stringBox);
        uiString.SetInfo(leaderName, score);

        return uiString;
    }
}


