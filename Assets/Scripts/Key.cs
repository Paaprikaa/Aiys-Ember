using UnityEngine;

public class Key : MonoBehaviour
{
    public GameLogic gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameLogic.getKey();
        Destroy(gameObject);
    }
}
