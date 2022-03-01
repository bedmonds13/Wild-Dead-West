using System;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gameScore { get; private set; }
    [SerializeField]
    private int winScore;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject EndMenu;
    [SerializeField]
    private CameraController mainCamera;
    [SerializeField]
    private CinemachineFreeLook freeLookCamera;


    private bool gamePaused;
    private GameObject player;
    private Spawner[] spawners;

    public int WinScore => winScore;
    public event Action OnScoreChange;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        spawners = FindObjectsOfType<Spawner>();
        if (GameManager.instance == null)
            instance = this;
        else
            Destroy(gameObject);

        gamePaused = false;
        pauseMenu.SetActive(gamePaused);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void increaseGameScore(int newPoints)
    {
        gameScore += newPoints;
        if (OnScoreChange != null)
            OnScoreChange();
    }

    internal void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        pauseMenu.SetActive(gamePaused);
        toggleActiveObjects();
    }
    internal void EndGame()
    {
        EndMenu.SetActive(true);
        toggleActiveObjects();
    }
    private void toggleActiveObjects()
    {
        player.SetActive(!player.activeSelf);
        freeLookCamera.enabled = (!freeLookCamera.isActiveAndEnabled);
        mainCamera.enabled = (!mainCamera.isActiveAndEnabled);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
            Cursor.lockState = CursorLockMode.Locked;

        foreach (var spawner in spawners)
        {
            spawner.ToggleSpawnedObjects();
        }
    }
}
