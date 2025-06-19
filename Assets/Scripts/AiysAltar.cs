using UnityEngine;

public class AiysAltar : MonoBehaviour
{
    public LightLogic lightLogic;
    public Vector3 respawnPosition;
    public PlayerData playerData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightLogic.inAltar = true;
        playerData.SaveCheckpoint(respawnPosition,gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lightLogic.inAltar = false;
    }
}
