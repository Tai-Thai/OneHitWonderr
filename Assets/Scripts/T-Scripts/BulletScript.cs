using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isMoveRight = true;
    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((isMoveRight ? Vector3.right : Vector3.left) * Time.deltaTime * speed);
    }

    public void SetIsMoveRight(bool isMoveRight)
    {
        this.isMoveRight = isMoveRight;
    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     print(other.gameObject.tag);
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
