using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        Move();       
    }

    // In start sends the ball to random direction and sets the ball rb velocity
    public void Move()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb2.velocity = new Vector2(speed * x, speed * y);
    }
}
