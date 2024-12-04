using UnityEngine;
using UnityEngine.SceneManagement;

public class BugCollision : MonoBehaviour
{
    public int Respawn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Respawn);
            //Debug.Log("h");
        }
    }
}