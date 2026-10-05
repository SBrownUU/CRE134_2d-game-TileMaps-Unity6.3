using UnityEngine;

public class PlatformerController : MonoBehaviour
{   
    abstract private class PlayerAction : Object
    {
        abstract public void enter();
        abstract public void exit();
        

    }

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Set to Dynamic with gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    void Update()
    {
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");
        
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("yo i should be jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    
    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
    
    // Visualise ground check in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}