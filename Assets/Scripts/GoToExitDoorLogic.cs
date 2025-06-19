using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToExitDoorLogic : MonoBehaviour
{
    public UILogic uiLogic;
    public AudioManager audioManger;
    public PlayerMovement playerMovement;
    public LightLogic lightLogic;

    [SerializeField] private bool _hasKey;


    private void Start()
    {
        //audioManger.Play("MainSong", 1f, 1f, true);
        Time.timeScale = 1f;
        lightLogic.maxLight = 10f;
    }

    public void OpenDoor()
    {
        // Win
        Time.timeScale = 0f;
        uiLogic.youWinUI.SetActive(true);
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
