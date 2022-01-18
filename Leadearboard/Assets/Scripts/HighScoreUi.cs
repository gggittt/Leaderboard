﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScoreUi : MonoBehaviour, IPointerClickHandler
{
    //public event Action<Leader> OnDestroy;
    public event Action<HighScoreUi> OnSelected;
    public event Action<HighScoreRecord> OnEdit;
    [SerializeField] private TextMeshProUGUI _index;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Image[] _bg;
    [SerializeField] private Color _selectColor;
    private bool _isSelected;
    private Color _startColor;
    public HighScoreRecord RecordData { get; private set; }

    private void Awake()
    {
        _startColor = _bg[0].color;
    }

    public void Init(HighScoreRecord highScoreRecord)
    {
        RecordData = highScoreRecord;
        _name.text = highScoreRecord.Name;
        _score.text = highScoreRecord.Score.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Right:
                OnEdit?.Invoke(RecordData);
                break;
            case PointerEventData.InputButton.Left when _isSelected:
                Deselect();
                break;
            case PointerEventData.InputButton.Left:
                Select();
                break;
        }
    }

    public void Deselect()
    {
        foreach (var item in _bg)
        {
            item.color = _startColor;
        }

        _isSelected = false;
    }

    private void Select()
    {
        OnSelected?.Invoke(this);
        foreach (var item in _bg)
        {
            item.color = _selectColor;
        }

        _isSelected = true;
    }

    public void ShiftIndex()
    {
        var newIndex = ++RecordData.Index;
        SetIndex(newIndex);
    }

    public void SetIndex(int index)
    {
        RecordData.Index = index;
        transform.SetSiblingIndex(index);
        _index.text = (index + 1).ToString();
    }
}