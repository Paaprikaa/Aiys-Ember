using UnityEngine;

public class AiysAltar : MonoBehaviour
{
    public LightLogic lightLogic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightLogic.inAltar = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lightLogic.inAltar = false;
    }
}
