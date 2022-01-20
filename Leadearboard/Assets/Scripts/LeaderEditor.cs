using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderEditor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _editedName;
    [SerializeField] private Text _editedScore;
    
    [SerializeField] private Transform _editUiPanel;

    [SerializeField] private Leaderboard _leaderboard;
    private HighScoreUi _oldEditedRecord;


    public void EditLeader()
    {
        HighScoreRecord newRecord = InputInfoGetter.TryGetInputsInfo(out bool isSuccess, _editedName.text, _editedScore.text);

        if (isSuccess == false)
            return;
        
        _leaderboard.EditLeaderRecord(_oldEditedRecord, newRecord);
    }

    public void RecordEditHandler(HighScoreUi sender)
    {
        _editUiPanel.gameObject.SetActive(true);
        _oldEditedRecord = sender;
    }

    public void ResetSelectedToEdit()//from ui button
    {
        _oldEditedRecord = null;
    }
}