using UnityEngine;

public class BugMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movespeed;
    public int patroldest;

    void Update()
    {
        if (patroldest == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, movespeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                patroldest = 1;
            }
        }
        if (patroldest == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, movespeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                patroldest = 0;
            }
        }
    }
}
