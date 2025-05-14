using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public int speed = 5;
   
    private bool isFacingRight;
    private Animator animator;
    private float moveInput;
    
    [Header("Jump")]
    public Transform feetPos;
    public float checkRadius;
    public float jumpForce = 5;
    public LayerMask whatIsGround;
    private float jumpCoolDown;
    private bool isJumping;
    [SerializeField] private float jumpTime = 0.25f;
    [SerializeField] private bool isGrounded;

    [Header("Fall Physics")]
    public float fallMultiplier;
    public float lowJumpMultiplier;

    void Start()
    {
        isFacingRight = true;
        isGrounded = true;
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        // jump logic
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded && Input.GetButtonDown("Jump")) {
            rb.linearVelocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpCoolDown = jumpTime;
        }

        // while holding jump button -> goes higher
        if(Input.GetButton("Jump") && isJumping) {
            if (jumpCoolDown > 0) { 
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpCoolDown -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }
    }

    // Has the frequency of the physics system; it is called every fixed frame-rate frame.
    void FixedUpdate()
    {
        // Horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        float horizontalAxisFloat = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed * Time.fixedDeltaTime, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", moveInput *  rb.linearVelocity.x);


        FlipSprite(horizontalAxisFloat);

        // jump fall physics.
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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
