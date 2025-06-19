using UnityEngine;
using UnityEngine.SceneManagement;

public class FindKeySceneLogic : MonoBehaviour
{
    public UILogic uiLogic;
    public LightLogic lightLogic;
    public CutSceneLogic cutSceneLogic;
    public GameObject inGameUI;
    public AudioManager audioManger;
    public GameObject player;
    public PlayerData playerData;   

    [SerializeField] private bool _hasKey;


    private void Start()
    {
        _hasKey = false;
        audioManger.Play("MainSong", 1f, 1f, true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_hasKey)
        {
            cutSceneLogic.StartCutScene();
            _hasKey = false;
        }
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

    public void RespawnPlayer()
    {
        lightLogic.currentLight = lightLogic.maxLight;
        inGameUI.SetActive(true);
        uiLogic.gameOverUI.SetActive(false);
        player.transform.position = playerData.lastPosition;
        playerData.RespawnSparkles();
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        uiLogic.gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
