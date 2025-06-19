using UnityEngine;
using UnityEngine.UI;

public class LightLogic : MonoBehaviour
{
    public Slider currentLightSlider;
    public UILogic uiLogic;
    public bool inAltar;
    public float maxLight = 20f;
    public PlayerData playerData;
    public float currentLight;
    [SerializeField] private bool _lightWorking = true;

    private void Awake()
    {
        inAltar = false;
        currentLight = maxLight;
        currentLightSlider.minValue = 0;
        currentLightSlider.maxValue = maxLight;
        currentLightSlider.value = currentLight;
    }

    private void Update()
    {
        if (!inAltar && _lightWorking)
        {
            currentLight -= Time.deltaTime;
            currentLightSlider.value = currentLight;
        }
        else
        {
            if ((currentLight < maxLight) && _lightWorking)
            {
                currentLight += Time.deltaTime;
                currentLightSlider.value = currentLight;
            }
        }


        if (currentLight < 0)
        {
            uiLogic.GameOver();
        }

    }

    public void addLight(GameObject light)
    {
        playerData.SaveSparkle(light);
        light.SetActive(false);
        currentLight = maxLight;
    }

    public void pauseLight()
    {
        _lightWorking = false;
    }
}
