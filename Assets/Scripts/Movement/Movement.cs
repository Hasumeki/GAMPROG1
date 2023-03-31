using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public static float horizontalcheck;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        ADMovement();
        // horizontal = Input.GetAxisRaw("Horizontal");
        horizontalcheck = horizontal;
        if (Input.GetKeyDown("w") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp("w") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void ADMovement()
    {
        if (Input.GetKey("a"))
            horizontal = -1.0f;
        else if (Input.GetKey("d"))
            horizontal = 1.0f;
        else
            horizontal = 0.0f;
        //god has forsaken me and its all your fault for wanting a local 2P game 
        //using input getaxisraw will take inputs from both WASD and arrow keys so I am forced to use input getkey
        //why did you not listen to me
        //removed A/D inputs from the unity input manager for this

    }
}
