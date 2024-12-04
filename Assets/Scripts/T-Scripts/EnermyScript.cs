using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyScript : MonoBehaviour
{
    public float start, end;
    public float offset = 5;
    public float speed = 5.0f;


    private bool isRight = false;

    public float damage = 10f;

    public float currentHP = 20f;

    public GameObject bombExplosionPrefab;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

        start = transform.position.x - offset;
        end = transform.position.x + offset;
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }

        float currentPosX = transform.position.x;

        if (currentPosX <= start)
        {
            isRight = false;
        }
        else if (currentPosX >= end)
        {
            isRight = true;
        }

        Vector3 direction = isRight ? Vector3.left : Vector3.right;

        // print(isRight);
        // print(direction * speed * Time.deltaTime);

        spriteRenderer.flipX = !isRight;
        // transform.localScale = new Vector3(isRight ? 1 : -1, 1, 1);

        transform.Translate(direction * speed * Time.deltaTime);
        // print(currentPosX + " " + transform.position.x);

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        // print("Enter 2d");
        if (other.gameObject.CompareTag("Patrol"))
        {
            isRight = !isRight;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerScript.Instance.ChangeHP(this.damage * -1);
        }

        // print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Projectile"))
        {
            currentHP -= 10f;
            Destroy(other.gameObject);
            if (bombExplosionPrefab)
            {
                Instantiate(bombExplosionPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
