using UnityEngine;
using UnityEngine.UI;

public class LightLogic : MonoBehaviour
{
    public Slider currentLightSlider;
    public UILogic uiLogic;
    public bool inAltar;
    public float maxLight;
    [SerializeField] private float _currentLight;
    [SerializeField] private bool _lightWorking = true;

    private void Start()
    {
        inAltar = false;
        _currentLight = maxLight;
        currentLightSlider.minValue = 0;
        currentLightSlider.maxValue = maxLight;
        currentLightSlider.value = _currentLight;
    }

    private void Update()
    {
        if (!inAltar && _lightWorking)
        {
            _currentLight -= Time.deltaTime;
            currentLightSlider.value = _currentLight;
        }
        else
        {
            if ((_currentLight < maxLight) && _lightWorking)
            {
                _currentLight += Time.deltaTime;
                currentLightSlider.value = _currentLight;
            }
        }


        if (_currentLight < 0)
        {
            uiLogic.GameOver();
        }

    }

    public void addLight(GameObject light)
    {
        Destroy(light);
        _currentLight = maxLight;
    }

    public void pauseLight()
    {
        _lightWorking = false;
    }
}
