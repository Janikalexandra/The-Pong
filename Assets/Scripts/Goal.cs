using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool isPlayerGoal;
    [SerializeField] private bool isAiGoal;

    [SerializeField] private bool canTrigger;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if(gameManager == null)
        {
            Debug.LogError("Game Manager is NULL!");
        }
    }

    // When ball triggers it will add points to the opposite of whose goal it is
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerGoal && canTrigger)
        {
            // A
            //gameManager.findBall = false;
            Destroy(collision.gameObject);

            // Disables bool so you can't get two triggers when getting a goal
            canTrigger = false;

            // Adds score
            gameManager.AddScore("AI", 1);

            StartCoroutine(Wait());
        }

        if (isAiGoal && canTrigger)
        {
            // Makes findBall false so AI so AI doesn't look for the ball more than once when needed
           // gameManager.findBall = false;

            Destroy(collision.gameObject);

            // Disables bool so you can't get two triggers when getting a goal
            canTrigger = false;

            // Adds score
            gameManager.AddScore("Player", 1);

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        canTrigger = true;
    }
}
