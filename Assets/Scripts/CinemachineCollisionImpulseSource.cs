using UnityEngine;

public class MyCollisionImpulseSource : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D; // Use 'new' keyword to hide the inherited member
    public float impulseForce = 10f; // Set your desired impulse force

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = rigidbody2D.linearVelocity;
        // Your custom logic here
    }
}
