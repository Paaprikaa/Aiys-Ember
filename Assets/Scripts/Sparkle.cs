using UnityEngine;

public class Sparkle : MonoBehaviour
{
    [SerializeField]  private LightLogic _gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameLogic.addLight(gameObject);
    }
}
