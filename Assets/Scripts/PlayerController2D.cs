using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int currentViewAngle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Adjust movement based on camera rotation
        switch (currentViewAngle)
        {
            case 0:  // Front view
                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
                break;
            case 90:  // Right side view
                rb.velocity = new Vector2(rb.velocity.x, moveInput * moveSpeed);  // Move up/down instead of left/right
                break;
            case 180:  // Back view
                rb.velocity = new Vector2(-moveInput * moveSpeed, rb.velocity.y);
                break;
            case 270:  // Left side view
                rb.velocity = new Vector2(rb.velocity.x, -moveInput * moveSpeed);  // Invert up/down movement
                break;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


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
