using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    private bool isJumping;
    public float gravityScale = 3f;
    private AudioSource audioSource;
    public AudioClip jumpsound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; // Adjust gravity scale here
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal"); // Using Input.GetAxisRaw for instant response
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump); // Using velocity for immediate movement
            audioSource.PlayOneShot(jumpsound);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
