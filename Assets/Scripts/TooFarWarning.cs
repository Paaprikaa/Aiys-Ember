using UnityEngine;

public class TooFarWarning : MonoBehaviour
{

    [SerializeField] private GameObject tooFarText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tooFarText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tooFarText.SetActive(true);
    }
}
