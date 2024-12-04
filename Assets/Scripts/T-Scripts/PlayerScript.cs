using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    public float health = 100f;
    public float mana = 50f;
    public float stamina = 75f;
    public GameObject bullet;
    public bool isMoveRight = true;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        // Ví dụ: Giảm mana khi sử dụng kỹ năng
        if (Input.GetKeyDown(KeyCode.F) && bullet)
        {
            UseSkill(10f);
        }

        // Kiểm tra trạng thái health
        // if (health <= 0)
        // {
        //     Die();
        // }
    }

    void OnShoot()
    {
        GameObject bulletObj = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletObj.GetComponent<BulletScript>().SetIsMoveRight(this.isMoveRight);
    }

    public void ChangeHP(float changeValue)
    {
        health += changeValue;
        Debug.Log("Player Health: " + health);
        GameManager.Instance.OnHPChange(health);
        if (health <= 0)
        {
            Die();
        }
    }


    public void UseSkill(float manaCost)
    {
        OnShoot();
        if (mana >= manaCost)
        {
            mana -= manaCost;
        }
        else
        {
            Debug.Log("Not enough mana!");
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        GameManager.Instance.GameOver();
    }

    public void SetIsMoveRight(bool isMoveRight)
    {
        this.isMoveRight = isMoveRight;
    }


    public void ResetPlayer()
    {
        isMoveRight = true;
        health = 100;
        mana = 50;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            GameManager.Instance.AddKey();
        }
    }



}
