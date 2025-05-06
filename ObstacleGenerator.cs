using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    //* Don't forget to make Fixed Timestep as 0.005

    int generationRate = 250;
    int timer;
    [SerializeField] GameObject pipePrefab;

    void FixedUpdate()
    {
        if (FirdBlapManager.gameStarted)
        {
            timer++;

            if (timer >= generationRate)
            {
                timer = 0;
                GameObject newObstacle = Instantiate(pipePrefab, new Vector2(pipePrefab.transform.position.x, pipePrefab.transform.position.y + Random.Range(-2.5f, 2.51f)), pipePrefab.transform.rotation);
                Destroy(newObstacle, 5f);
            }
        }
    }
}
