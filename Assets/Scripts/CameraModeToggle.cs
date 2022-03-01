using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] firstPersonObjects;
    [SerializeField]
    private GameObject[] thirdPersonObjects;

    [SerializeField]
    private KeyCode toggleKey = KeyCode.F1;
    private bool isFpsMode;
    private Weapons weapon;
    private CameraController cameraControler;

    public event Action OnToggle;


    private void Awake()
    {
        weapon = FindObjectOfType<Weapons>();
        cameraControler = FindObjectOfType<CameraController>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }
    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    private void Toggle()
    {
        weapon.isFpsMode = !weapon.isFpsMode;
        isFpsMode = !isFpsMode;
        if(OnToggle != null)
            OnToggle();
        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(isFpsMode);
            cameraControler.ResetCameraOrientation_OnToggle();
        }
        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!isFpsMode);
        }
    }
}
