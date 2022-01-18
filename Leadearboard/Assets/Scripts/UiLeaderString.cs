using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiLeaderString : MonoBehaviour, IPointerClickHandler
{
    private Leader _data;
    public event Action<Leader> OnDestroy; 
    [SerializeField] private TextMeshProUGUI _index;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;

    public void SetInfo(Leader leader)
    {
        _data = leader;
        _name.text = leader.Name;
        _score.text = leader.Score.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Delete();
        }
    }

    private void Delete()
    {
        Debug.Log($"<color=cyan> удаляю {_data.Name}  </color>");
        OnDestroy?.Invoke(_data);
        Destroy(gameObject);
    }
}


