using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // public AudioSource audioSource;

    public GameObject explosion;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        print(itemName + "On Enter 2d");
        if (other.gameObject.CompareTag("Player"))
        {
            // audioSource?.Play();

            OnPlayerEnter();

            if (explosion)
            {

                GameObject explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public virtual void OnPlayerEnter()
    {
        Debug.Log("Player entered an item zone.");
    }

}
