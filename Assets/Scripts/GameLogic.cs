using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject GameOverUI;
    public GameObject inGameUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Pause menu //
    public void PauseGame()
    {
        if(pauseUI.activeSelf) {
            // continue game
            pauseUI.SetActive(false);
            inGameUI.SetActive(true);
            Time.timeScale = 1f;

        } else
        {
            // pause game
            pauseUI.SetActive(true);
            inGameUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    // Game over menu //
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Debug.Log("game over");
    }
}
