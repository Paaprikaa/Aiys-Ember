using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    public EscapeSceneLogic gameLogic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameLogic.OpenDoor();
    }

}
