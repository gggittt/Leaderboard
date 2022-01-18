using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LeaderAdder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  _nameText;
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TextMeshProUGUI  _scoreText;
    [SerializeField] private TMP_InputField _scoreInput;
    [SerializeField] private Leaderboard _leaderboard;

    public void AddNewLeader()
    {
        Debug.Log($"<color=cyan> {_nameInput.GetComponentInChildren<TextMeshProUGUI>().text}  </color>");
        Debug.Log($"<color=cyan> {_scoreInput.GetComponent<TextMeshProUGUI>().text}  </color>");
    }
    /*public void AddNewLeader()
    {
        var isParsed = int.TryParse(_scoreInput.text, out int score);

        Debug.Log($"<color=cyan> {isParsed}, {_scoreInput.text} = {score}  </color>");

        if (isParsed)
        {
            _leaderboard.AddLeader(_nameText.text, score);
            
        }
        else
        {
            Debug.Log($"<color=cyan> Score insert incorrectly!  </color>");
        }
    }*/
}