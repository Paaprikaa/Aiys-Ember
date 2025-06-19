using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneLogic : MonoBehaviour
{
    [Header("UI element")]
    public GameObject cutSceneUI;
    public GameObject allIntroductionText;
    public GameObject invisibleWalls;
    public Image backgroundCutScene;
    public TMP_Text cutSceneText;

    [Header("Scripts and variables")]
    public CameraBehavior mainCamera;
    public AudioManager audioManger;
    public LightLogic lightLogic;

    [SerializeField] private float timeBetweenTexts = 4f;
    private string[] textsForCutScene;

    void Start()
    {
        Transform backgroundTransform = cutSceneUI.transform.Find("Background black");

        if (backgroundTransform != null)
        {
            backgroundCutScene = backgroundTransform.GetComponent<Image>();
        }
        else
        {
            Debug.LogWarning("Couldn't find Background black");
        }
        // Initializing cut scene text
        textsForCutScene = new string[4];
        textsForCutScene[0] = "You thought you were safe";
        textsForCutScene[1] = "Good luck finding the door";
        textsForCutScene[2] = "Now...";
        textsForCutScene[3] = "ESCAPE";
    }

    public void StartCutScene()
    {
        audioManger.Stop("MainSong");
        invisibleWalls.SetActive(true);
        allIntroductionText.SetActive(false);
        lightLogic.pauseLight();
        // audioManger.Play("RockSmash"); not working
        StartCoroutine(mainCamera.Shake());
        cutSceneUI.SetActive(true);
        StartCoroutine(ShowCutSceneText());
    }

    private IEnumerator ShowCutSceneText()
    {
        float timeCounter = 0f;
        for (int textCounter = 0; textCounter < textsForCutScene.Count(); textCounter++)
        {
            if (textCounter == 2 && backgroundCutScene != null) backgroundCutScene.color = new Color(0f, 0f, 0f, 1f);
            cutSceneText.text = textsForCutScene[textCounter];
            while (timeCounter < timeBetweenTexts)
            {
                timeCounter += Time.deltaTime;
                yield return null;
            }
            timeCounter = 0f;
        }
    }

}
