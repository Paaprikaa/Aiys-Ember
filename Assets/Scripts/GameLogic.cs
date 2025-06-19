using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public UILogic uiLogic;
    public AudioManager audioManger;

    [SerializeField] private bool _hasKey;
    

    private void Start()
    {
        _hasKey = false;
        audioManger.Play("MainSong", 1f, 1f, true);
        Time.timeScale = 0f;
    }


    public void getKey()
    {
        _hasKey = true;
    }

    public void canOpenDoor()
    {
        if (_hasKey)
        {
            // Win
            Time.timeScale = 0f;
            uiLogic.youWinUI.SetActive(true);
        }
    }

    // Button functions //
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        uiLogic.gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }    
}
