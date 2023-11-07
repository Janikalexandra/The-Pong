using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private bool isPaused;

    [SerializeField] private TMP_Text whoScoredText;

    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text AiScoreText;

    [SerializeField] private int playerScore;
    [SerializeField] private int AiScore;

    [SerializeField] private GameObject ball;
    [SerializeField] private Vector2 ballSpawnPosition;

    [SerializeField] private float timeTillBallSpawnsAgain;

    public bool findBall;

    [SerializeField] private AudioClip ballSound;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        AiScore = 0;

        playerScoreText.text = playerScore.ToString();
        AiScoreText.text = AiScore.ToString();

        SpawnBall();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Pauses the game and shows the pause panel
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }      
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(ballSound);
    }

    // Adds score depenging on the string and int to who scores and how much
    public void AddScore(string name,int pointAmount)
    {
        if(name == "Player")
        {
            playerScore += pointAmount;
            playerScoreText.text = playerScore.ToString();

            whoScoredText.text = "Player Scores!";

            StartCoroutine(NewBall());

        }

        if(name == "AI")
        {
            AiScore += pointAmount;
            AiScoreText.text = AiScore.ToString();

            whoScoredText.text = "AI Scores!";

            StartCoroutine(NewBall());
        }
    }

    // Waits till new ball is spawned and sets the text to null
    IEnumerator NewBall()
    {
        yield return new WaitForSeconds(timeTillBallSpawnsAgain);
        findBall = true;
        whoScoredText.text = "";

        // Spawns new ball
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(ball, ballSpawnPosition, ball.transform.rotation);
    }
}
