using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDestroyThis()
    {
        Destroy(gameObject);
    }
}
