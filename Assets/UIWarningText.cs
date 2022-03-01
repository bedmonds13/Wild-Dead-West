using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWarningText : MonoBehaviour
{
    private TextMeshProUGUI warningText;

    
    private void Awake()
    {
        warningText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        int winScore = GameManager.instance.WinScore;
        int currentScore = GameManager.instance.gameScore;
        int pointsleftToWin = winScore - currentScore;
        warningText.text = "You must get " + winScore+" points before escaping." +
            " You just need " + pointsleftToWin + " to go!"; 
    }
}
