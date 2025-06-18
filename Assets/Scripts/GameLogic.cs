using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject GameOverUI;
    public GameObject inGameUI;
    public GameObject YouWinUI;
    public AudioManager audioManger;

    [SerializeField] private bool hasKey;

    private void Start()
    {
        hasKey = false;
        audioManger.Play("MainSong", 1f, 1f, true);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void getKey()
    {
        hasKey = true;
    }

    public void canOpenDoor()
    {
        if (hasKey)
        {
            // win
            Time.timeScale = 0f;
            YouWinUI.SetActive(true);
        }
    }

    // Button functions //


    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    // Pause menu //
    public void PauseGame()
    {
        if (pauseUI.activeSelf)
        {
            // continue game
            pauseUI.SetActive(false);
            inGameUI.SetActive(true);
            Time.timeScale = 1f;

        }
        else
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
        inGameUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
}
