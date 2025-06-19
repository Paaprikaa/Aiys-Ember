using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public FindKeySceneLogic gameLogic;
    [SerializeField] private GameObject doorText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameLogic.canOpenDoor();
        doorText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorText.SetActive(false);
    }
}
