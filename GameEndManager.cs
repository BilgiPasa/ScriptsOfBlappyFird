using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    bool endManagerUsed;
    [SerializeField] GameObject scoreText, endMenu;
    [SerializeField] AudioSource gameEndSound;

    void Update()
    {
        if (FirdBlapManager.gameEnded && !endManagerUsed)
        {
            EndManager();
        }
    }

    void EndManager()
    {
        gameEndSound.Play();
        scoreText.SetActive(false);
        endMenu.SetActive(true);
        Time.timeScale = 0;
        endManagerUsed = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        FirdBlapManager.gameEnded = false;
        endManagerUsed = false;
        FirdBlapManager.gameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
