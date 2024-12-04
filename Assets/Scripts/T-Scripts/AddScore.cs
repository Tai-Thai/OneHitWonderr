using UnityEngine;

public class AddScore : ItemScript
{
    public float score = 10f;

    public override void OnPlayerEnter()
    {
        GameManager.Instance.AddScore(score);
    }
}
