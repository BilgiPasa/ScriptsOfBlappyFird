using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))] // This script requires to have a Rigidbody2D component

public class FirdBlapManager : MonoBehaviour
{
    int score, jumpPower = 13;
    public static bool gameStarted, gameEnded, normalCanFlap, firstCanFlap;
    KeyCode jumpButton = KeyCode.Space, exitKey = KeyCode.Escape;
    Rigidbody2D rb;
    [SerializeField] TextMeshProUGUI scoreText, endScoreText, highscoreText;
    [SerializeField] AudioSource firdBlap;
    [SerializeField] AudioSource scoreSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Time.timeScale == 1 && !gameEnded)
        {
            if (gameStarted && (Input.GetKeyDown(jumpButton) || Input.GetMouseButtonDown(0)))
            {
                normalCanFlap = true;
            }
            else if (!gameStarted)
            {
                if (Input.GetKeyDown(jumpButton) || Input.GetMouseButtonDown(0))
                {
                    firstCanFlap = true;
                }
                else if (Input.GetKeyDown(exitKey))
                {
                    Application.Quit();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (normalCanFlap)
        {
            firdBlap.Play();
            rb.velocity = new Vector2(0, jumpPower);
            normalCanFlap = false;
        }
        else if (firstCanFlap)
        {
            firdBlap.Play();
            rb.velocity = new Vector2(0, jumpPower);
            rb.gravityScale = 4;
            gameStarted = true;
            firstCanFlap = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            scoreSound.Play();
            score++;
            scoreText.text = score.ToString();
            endScoreText.text = score.ToString();
        }
    }


    void OnCollisionEnter2D(Collision2D collision) // For walls
    {
        if (!collision.gameObject.CompareTag("GroundOrRoof"))
        {
            GameEnd();
        }
    }
    // I made 2 different collision detections to prevent a visual and a game bug.
    void OnCollisionStay2D(Collision2D collision) // For ground, roof and walls
    {
        GameEnd();
    }

    void GameEnd()
    {
        gameStarted = false;
        gameEnded = true;

        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
