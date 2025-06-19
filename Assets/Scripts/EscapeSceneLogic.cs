using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSceneLogic : MonoBehaviour
{
    public UILogic uiLogic;
    public LightLogic lightLogic;
    public AudioManager audioManger;



    private void Start()
    {
        //audioManger.Play("MainSong", 1f, 1f, true);
        Time.timeScale = 1f;
        lightLogic.maxLight = 8f;
    }

    public void OpenDoor()
    {
        // Win
        Time.timeScale = 0f;
        uiLogic.winUI();
    }

    // Button functions //
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        uiLogic.gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
