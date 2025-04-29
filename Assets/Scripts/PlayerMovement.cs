using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public SpriteRenderer sprite;
    public int speed = 5;
    private bool isFacingRight;
    private Animator animator;

    void Start()
    {
        isFacingRight = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        
        FlipSprite(horizontalAxis);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.linearVelocity = Vector2.left * speed;
            animator.SetFloat("xVelocity", -playerBody.linearVelocity.x);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerBody.linearVelocity = Vector2.right * speed;
            animator.SetFloat("xVelocity", playerBody.linearVelocity.x);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
            animator.SetFloat("xVelocity", 0f);
        }
    }

    private void FlipSprite(float horizontalAxis) {
        if(isFacingRight && horizontalAxis < 0f || !isFacingRight && horizontalAxis > 0f)
        {
            sprite.flipX = isFacingRight;
            isFacingRight = !isFacingRight;
        }
    }

}
