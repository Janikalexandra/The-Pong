using UnityEngine;

public class AiMovement : MonoBehaviour
{

    [SerializeField] private GameObject ball;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 ballPosition;
    [SerializeField] float ballYAxes;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballPosition.x = 8;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ball = GameObject.Find("Ball");

        if (gameManager == null)
        {
            Debug.LogError("Game Manager is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null)
        {
            ballYAxes = ball.transform.position.y;

            ballPosition.y = ball.transform.position.y;
        }

        // Finds ball
        FindBall();

        // Follows Ball after finding the ball
        FollowBall();
    }

    private void FollowBall()
    {
        if(ball != null)
        {      
            //transform.position = new Vector2(9,ballYAxes);
            transform.position = Vector2.MoveTowards(transform.position, ballPosition, speed * Time.deltaTime);
        }
    }

    // Finds the ball in the start and when new ball is spawned
    private void FindBall()
    {
        if(ball == null && gameManager.findBall == true)
        {          
            ball = GameObject.FindGameObjectWithTag("Ball");
            gameManager.findBall = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gameManager.PlaySound();
    }



}
