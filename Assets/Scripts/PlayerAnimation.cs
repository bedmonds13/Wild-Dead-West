using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    private float drawWeaponSpeed = 1f;
    [SerializeField]
    private float delayBeforeWeaponHolster = 0.25f;


    private Coroutine currentFadeRoutine;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(currentFadeRoutine != null)
                StopCoroutine(FadeToShootingLayer());
            currentFadeRoutine = StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (currentFadeRoutine != null)
                StopCoroutine(FadeToShootingLayer());
            currentFadeRoutine = StartCoroutine(FadeToBaseLayer());
        }
        
    }

    private IEnumerator FadeToBaseLayer()
    {
        yield return currentFadeRoutine;

        yield return new WaitForSeconds(delayBeforeWeaponHolster);

        
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;
        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;  
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;

        }
        animator.SetLayerWeight(1, 0);
    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;
        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;  
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;

        }
        animator.SetLayerWeight(1, 1);
    }
}
