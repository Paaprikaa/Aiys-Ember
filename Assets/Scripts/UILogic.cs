using UnityEngine;
using UnityEngine.SceneManagement;


public class UILogic : MonoBehaviour
{
    [Header("UI element")]
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject inGameUI;
    public GameObject youWinUI;
    public GameObject introductionUI;

    [SerializeField] private bool introductionShown;

    private void Start()
    {
        introductionShown = SceneManager.GetActiveScene().name == "Escape";
        introductionUI.SetActive(!introductionShown);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !introductionShown)
        {
            introductionUI.SetActive(false);
            Time.timeScale = 1f;
            introductionShown = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void winUI()
    {
        inGameUI.SetActive(false);
        youWinUI.SetActive(true);
        Time.timeScale = 0f;
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
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
