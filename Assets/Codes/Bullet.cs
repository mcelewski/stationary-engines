using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    int direction = 1;                                      // It controls if bullet moves up or down

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {                                                       // Bullet that player shoots moves with 40 (units) speed...
        rb.velocity = new Vector2(0, 40 * direction);       // ...in this case it moves up...
    }                                                       // ...because 40 * 1 = 40 (and 40 is y value in this case)

    public void ChangeDirection()
    {                                                       // When this method is called in Enemy.cs file...
        direction *= -1;                                    // ...bullet that enemies shoot is set to move down...
    }                                                       // ...because 40 * (-1) = -40 (and -40 is y value in this case)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (direction == 1)                                 // Statement set for player (because direction is set to 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {                                               // If there's a collision between bullet and...    
                collision.gameObject.                       // ...object which is our enemy (that's set by tag)...
                GetComponent<Enemy>().Damage();             // ...then perform "Damage" method included in "Enemy.cs" file...
                Destroy(gameObject);                        // ...and destroy bullet after it hits the enemy
            }
        }
        else                                                // Statement set for enemies (in this case direction = -1)
        {
            if (collision.gameObject.tag == "Player")
            {                                               // If there's a collision between bullet and our spaceship...
                collision.gameObject.                       // ...then perform "Damage" method included in "SpaceshipSteering.cs" file...
                GetComponent<SpaceshipSteering>().Damage(); // ...and destroy bullet after it hits us
                Destroy(gameObject);
            }
        }
    }
}
