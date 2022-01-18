using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private readonly List<HighScoreUi> _leaders = new List<HighScoreUi>();
    private HighScoreUi _selected;

    [SerializeField] private Transform _stringBox;
    [SerializeField] private HighScoreUi _stringPrefab;

    private void Start()
    {
        foreach (var point in _stringBox.GetComponentsInChildren<HighScoreUi>())
        {
            _leaders.Add(point);
            point.OnSelected += StringSelectHandler;
            point.OnEdit += StringEditHandler;
        }
    }

    public void AddLeaderRecord(HighScoreRecord highScoreRecord)
    {
        HighScoreUi highScoreUiString = Instantiate(_stringPrefab, _stringBox);
        highScoreUiString.Init(highScoreRecord);
        RecomposeIndexesAfterAdd(highScoreUiString);
        _leaders.Add(highScoreUiString);
        //uiString.OnDestroy += StringDeleteHandler;
        highScoreUiString.OnSelected += StringSelectHandler;
        highScoreUiString.OnEdit += StringEditHandler;
    }

    public void DeleteAll()
    {
        foreach (HighScoreUi point in _leaders.ToList())
        {
            DeleteRecord(point);
        }
    }

    private void DeleteRecord(HighScoreUi record)
    {
        _leaders.Remove(record);
        Destroy(record.gameObject);
    }

    public void DeleteSelected()
    {
        if (_selected == null)
            return;
        Debug.Log($"<color=cyan> удаляю {_selected}  </color>");
        DeleteRecord(_selected);
    }

    private void RecomposeIndexesAfterAdd(HighScoreUi current)
    {
        var lowerIndexes = new List<HighScoreUi>();

        var resultIndex = _leaders.Count;
        foreach (HighScoreUi point in _leaders)
        {
            if (current.RecordData.Score > point.RecordData.Score)
            {
                bool isCurrentHigherInHierarchy = resultIndex > point.RecordData.Index;
                if (isCurrentHigherInHierarchy)
                {
                    resultIndex = point.RecordData.Index;
                }

                lowerIndexes.Add(point);
            }
        }

        foreach (HighScoreUi point in lowerIndexes)
        {
            point.ShiftIndex();
        }

        current.SetIndex(resultIndex);
    }
    

    private void StringEditHandler(HighScoreRecord obj)
    {
        //открыть окно Edit
        //передать в след логику obj
    }

    private void StringSelectHandler(HighScoreUi sender)
    {
        if (_selected != null)
            _selected.Deselect();
        
        _selected = sender;
    }


    public void EditLeader(string nameInputText, int result)
    {
        //_editor.EditLeader(nameInputText, result);
    }
}