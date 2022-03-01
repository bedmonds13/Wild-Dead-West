using UnityEngine;
using TMPro;
public class UIScoreBoard : MonoBehaviour
{
    private int currentScore;
    private TextMeshProUGUI scoreBoardText;

    private void Awake()
    {
        scoreBoardText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        scoreBoardText.text = currentScore.ToString();
        GameManager.instance.OnScoreChange += UpdateScoreboard_OnScoreChanged;
    }

    private void UpdateScoreboard_OnScoreChanged()
    {
        scoreBoardText.text = GameManager.instance.gameScore.ToString();
    }

    private void OnDestroy()
    {
        GameManager.instance.OnScoreChange -= UpdateScoreboard_OnScoreChanged;
    }
}
