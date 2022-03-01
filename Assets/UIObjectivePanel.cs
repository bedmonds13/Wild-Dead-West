using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIObjectivePanel : MonoBehaviour
{
    [SerializeField]
    private float fadeDelay;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        text.text = "Gain " + GameManager.instance.WinScore + " points in order to escape succesfully!";
        StartCoroutine(PanelFade(fadeDelay));
    }

    
    private IEnumerator PanelFade(float delay )
    {
        text.text = "Gain " + GameManager.instance.WinScore + " points in order to escape succesfully!";
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
