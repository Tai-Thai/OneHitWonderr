using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    private bool playerInCollision = false;

    void Update()
    {
        if (playerInCollision && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Level One");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInCollision = false;
        }
    }
}