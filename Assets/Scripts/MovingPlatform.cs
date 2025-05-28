using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform From;
    public Transform To;
    public float speed;
    public PlayerMovement player;
    [SerializeField] private bool goForward;
    [SerializeField] private bool goBack;

    private void Start()
    {
        goForward = false;
        goBack = false;
    }

    private void Update()
    {
        // move platform
        if (goForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, To.position, speed * Time.deltaTime);
        }
        if (goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, From.position, speed * Time.deltaTime);
        }

        // if reach destination point
        if (transform.position == To.position)
        {
            goForward = false;
            StartCoroutine(WaitToGoBack());
        }
        // if platform has return
        if (transform.position == From.position)
        {
            goBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.isGrounded)
        {
            if (!goBack)
            {
                goForward = true;
            }
            collision.gameObject.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.activeInHierarchy)
        {
            collision.gameObject.transform.SetParent(null, true);
        }
    }

    private IEnumerator WaitToGoBack()
    {
        yield return new WaitForSeconds(4);
        goBack = true;
        yield return null;
    }
}
