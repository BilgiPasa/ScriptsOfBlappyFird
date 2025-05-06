using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    float moveSpeed = 0.25f;

    void FixedUpdate()
    {
        if (FirdBlapManager.gameStarted)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - moveSpeed, transform.position.y), 0.1f);
        }
    }
}
