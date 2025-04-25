using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public int speed = 8;
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.linearVelocity = Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerBody.linearVelocity = Vector2.right * speed;
        }
    }

}
