using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public static bool gamePaused;
    KeyCode PauseKey = KeyCode.Escape;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Rigidbody2D FirdRb;

    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(PauseKey) && !gamePaused && FirdRb.gravityScale == 4 && !FirdBlapManager.gameEnded)
        {
            Pause();
        }
        else if (Input.GetKeyDown(PauseKey) && gamePaused)
        {
            Resume();
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void QuittingGame()
    {
        Application.Quit();
    }
}
