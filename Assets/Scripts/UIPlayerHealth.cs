using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthFillBar;

    private void Start()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnHealthChanged += UIPlayerHealth_OnHealthChanged;    
    }

    private void UIPlayerHealth_OnHealthChanged(int currentHealth, int maxHealth)
    {
        float pct = (float)currentHealth / (float)maxHealth;
        healthFillBar.fillAmount = pct;
    }
}
