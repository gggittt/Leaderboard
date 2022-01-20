using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private List<HighScoreUi> _leaders = new List<HighScoreUi>();
    private HighScoreUi _selected;

    [SerializeField] private Transform _stringBox;
    [SerializeField] private HighScoreUi _stringPrefab;

    [SerializeField] private LeaderEditor _editor;
    //когда 2 класса имеют ссылки на друг друга это не верно по архитектуре, но как иначе оформить подписку - не придумал

    public void AddLeaderRecord(HighScoreRecord highScoreRecord)
    {
        HighScoreUi highScoreUiString = Instantiate(_stringPrefab, _stringBox);
        highScoreUiString.Init(highScoreRecord);
        
        highScoreUiString.OnEdit += _editor.RecordEditHandler;
        highScoreUiString.OnSelected += RecordSelectHandler;
        
        _leaders.Add(highScoreUiString);
        RecalculateLeaders();
    }

    public void DeleteAll()
    {
        foreach (HighScoreUi point in _leaders.ToList())
        {
            DeleteRecord(point);
        }

        RecalculateLeaders();
    }

    private void RecalculateLeaders()
    {
        _leaders = GetOrderedRecords();

        List<HighScoreUi> GetOrderedRecords() =>
            _leaders.OrderBy(item => 
                item.RecordData.Score).Reverse().ToList();


        for (int i = 0; i < _leaders.Count; i++)
        {
            _leaders[i].SetIndex(i);
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

        DeleteRecord(_selected);
        RecalculateLeaders();
    }
    
    private void RecordSelectHandler(HighScoreUi sender)
    {
        if (_selected != null)
            _selected.Deselect();

        _selected = sender;
    }

    public void EditLeaderRecord(HighScoreUi oldEditedRecord, HighScoreRecord newRecord)
    {
        DeleteRecord(oldEditedRecord);
        AddLeaderRecord(newRecord);
    }
}