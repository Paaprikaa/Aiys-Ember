using UnityEngine;
using UnityEngine.UI;

public class LightLogic : MonoBehaviour
{
    public Slider currentLightSlider;
    public UILogic uiLogic;
    public bool inAltar;
    [SerializeField] private float _currentLight;
    [SerializeField] private float _maxLight = 50f;

    private void Start()
    {
        inAltar = false;
        _currentLight = _maxLight;
        currentLightSlider.minValue = 0;
        currentLightSlider.maxValue = _maxLight;
        currentLightSlider.value = _currentLight;
    }

    private void Update()
    {
        if (!inAltar)
        {
        _currentLight -= Time.deltaTime;
        currentLightSlider.value = _currentLight;
        }


        if (_currentLight < 0)
        {
            uiLogic.GameOver();
        }

    }

    public void addLight(GameObject light)
    {
        Destroy(light);
        _currentLight = _maxLight;
    }

}
