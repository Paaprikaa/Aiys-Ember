using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Slider currentLightSlider;
    [SerializeField] private float _currentLight;
    [SerializeField] private float _maxLight = 50f;

    private void Start()
    {
        _currentLight = _maxLight;
        currentLightSlider.minValue = 0;
        currentLightSlider.maxValue = _maxLight;
        currentLightSlider.value = _currentLight;
    }

    private void Update()
    {
        _currentLight -= Time.deltaTime;
        currentLightSlider.value = _currentLight;


        if (_currentLight<0)
        {
            GameOver();
        }

    }

    public void addLight(GameObject light)
    {
        Destroy(light);
        _currentLight = _maxLight;
    }

    private void GameOver()
    {
        Debug.Log("game over");
    }

}
