using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    int obstacleSpeed = 8;
    Rigidbody2D obstacleRigidbody;

    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
        obstacleRigidbody.bodyType = RigidbodyType2D.Kinematic;
        obstacleRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        obstacleRigidbody.sleepMode = RigidbodySleepMode2D.NeverSleep;
        obstacleRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
        obstacleRigidbody.freezeRotation = true;
        obstacleRigidbody.velocity = new Vector2(-obstacleSpeed, 0);
    }
}
