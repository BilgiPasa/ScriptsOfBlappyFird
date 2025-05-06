using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject startText, startText2, scoreText;

    void Update()
    {
        if (FirdBlapManager.gameStarted)
        {
            startText.SetActive(false);
            startText2.SetActive(false);
            scoreText.SetActive(true);
        }
    }
}
