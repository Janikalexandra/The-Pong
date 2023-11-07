using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("Game Manager is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Player moves up and down with W and S
    private void Movement()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    // Makes the blop sound when having a collision with the ball
    private void OnCollisionExit2D(Collision2D collision)
    {
        gameManager.PlaySound();
    }
}
