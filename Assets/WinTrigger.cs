using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject winConditionImage;
    [SerializeField]
    UIWarningText warningText;

    private bool WinCondition;
    
    private void OnTriggerEnter(Collider other)
    {

        WinCondition = GameManager.instance.gameScore >= GameManager.instance.WinScore;
        if (other.GetComponent<PlayerMovement>() && !WinCondition)
        {
            winConditionImage.SetActive(true);
            warningText.UpdateText();
        }
        else
        {
            GameManager.instance.EndGame();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            winConditionImage.SetActive(false);
        }
    }
}
