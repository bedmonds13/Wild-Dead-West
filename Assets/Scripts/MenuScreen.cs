
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Town");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadSettingsMenu()
    {
        SceneManager.LoadScene("Controls");
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
