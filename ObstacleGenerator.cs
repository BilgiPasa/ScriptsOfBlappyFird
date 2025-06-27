using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    float generationSeconds = 1.5f, timer;
    [SerializeField] GameObject pipePrefab;

    void FixedUpdate()
    {
        if (FirdBlapManager.gameStarted)
        {
            timer += Time.fixedDeltaTime;

            if (timer >= generationSeconds)
            {
                timer = 0;
                GameObject newObstacle = Instantiate(pipePrefab, new Vector2(pipePrefab.transform.position.x, pipePrefab.transform.position.y + Random.Range(-2.5f, 2.51f)), pipePrefab.transform.rotation);
                Destroy(newObstacle, 5);
            }

            generationSeconds -= 0.00002f; // To make the game harder
        }
    }
}
