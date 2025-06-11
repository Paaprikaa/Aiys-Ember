using UnityEngine;

public class Sparkle : MonoBehaviour
{
    [SerializeField]  private GameLogic _gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameLogic.addLight(gameObject);
    }
}
