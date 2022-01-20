using System;
using UnityEngine;

public static class InputInfoGetter
{
    public static HighScoreRecord TryGetInputsInfo(out bool isSuccess, string newName, string scoreString)
    {
        isSuccess = true;
        
        var isScoreStringParsed = int.TryParse(scoreString.Trim(), out int score);
        
        if (newName == String.Empty)
        {
            Debug.Log($"<color=cyan> Name can't be empty!  </color>");
            isSuccess = false;
        }

        if (isScoreStringParsed == false)
        {
            Debug.Log($"<color=cyan> Score insert incorrectly! ({scoreString}) </color>");
            isSuccess = false;
        }

        return new HighScoreRecord(newName, score);
    }
}