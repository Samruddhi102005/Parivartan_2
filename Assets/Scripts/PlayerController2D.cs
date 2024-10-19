using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float depthOffset = 0.1f;  // How much the player changes depth while moving up/down
    private Rigidbody2D rb;
    private bool isGrounded;

    private SpriteRenderer spriteRenderer;  // For adjusting sorting order

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get input for horizontal (left/right) and vertical (up/down) movement
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveInputVertical = Input.GetAxis("Vertical");

        // Move the player along the X and Y axes
        rb.velocity = new Vector2(moveInputHorizontal * moveSpeed, rb.velocity.y);

        // Handle "front/back" movement by moving on the Y-axis
        transform.position += new Vector3(0, moveInputVertical * moveSpeed * Time.deltaTime, 0);

        // Simulate depth by adjusting Z position or sorting layer based on Y-axis movement
        if (moveInputVertical != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * depthOffset);
        }

        // Flip sprite if moving left or right (optional)
        if (moveInputHorizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInputHorizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Check if the player is grounded to allow jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}