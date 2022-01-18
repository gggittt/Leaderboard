using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLeaderString : MonoBehaviour
{

    [SerializeField] private Text _name;
    [SerializeField] private Text _score;

    public void SetInfo(string leaderName, int score)
    {
        _name.text = leaderName;
        _score.text = score.ToString();
    }

}


