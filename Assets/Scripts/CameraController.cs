using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("Third Person Attributes")]
    [SerializeField]
    CinemachineVirtualCamera followCamera;
    [SerializeField]
    CinemachineFreeLook freeLookCamera;
    [SerializeField]
    private float thirdPersonMouseSensitivity_Y = 1f;

    [Header("First Person Attributes")]
    [SerializeField]
    CinemachineVirtualCamera fpsCamera;
    [SerializeField]
    private float firstPersonMouseSensitivity = 1f;
    [SerializeField]
    private float fpsDefaultOffset_Y = 0;

    private CinemachineComposer aim;
    private CameraModeToggle cameraModeToggle;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
        cameraModeToggle = FindObjectOfType<CameraModeToggle>();
        cameraModeToggle.OnToggle += ResetCameraOrientation_OnToggle;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (Input.GetMouseButton(1) == false)
        { 
        var vertical = Input.GetAxis("Mouse Y") * thirdPersonMouseSensitivity_Y;
        aim.m_TrackedObjectOffset.y += vertical;
        aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, 0f, 10f);
        }


        var fpsVertical = Input.GetAxis("Mouse Y") * firstPersonMouseSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);
    }

    public void ResetCameraOrientation_OnToggle()
    {
        //aim.m_TrackedObjectOffset.y = 1.5f;
    }
    private void OnDestroy()
    {
        cameraModeToggle.OnToggle -= ResetCameraOrientation_OnToggle;
    }

}
