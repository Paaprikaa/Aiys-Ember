using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public AudioManager audioManger;
    void Start()
    {
        audioManger.Play("MenuSong", 1f, 1f, true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("FindKey");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
