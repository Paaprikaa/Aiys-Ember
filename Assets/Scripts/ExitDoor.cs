using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameLogic gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameLogic.canOpenDoor();
    }
}
