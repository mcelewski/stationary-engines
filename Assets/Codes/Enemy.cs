using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject bullet;
    public GameObject explosion;

    [SerializeField] private float enemyXSpeed;
    [SerializeField] private float enemyYSpeed;
    [SerializeField] private float enemyFireRate;
    [SerializeField] private int scoreCounter;

    int enemyHealth = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        enemyFireRate = enemyFireRate +                     // Overall enemy fire rate is a sum of his constant fire rate value...
            (Random.Range(enemyFireRate / (-1.5f),          // ...(that is set in Unity for every kind of enemy)...
            enemyFireRate / 1.5f));                         // ...plus random fire rate value (randomized from this code)

            InvokeRepeating("Shoot", enemyFireRate,         // Invokes "Shoot" method in 'each enemy fire rate' seconds from launching...
                enemyFireRate);                             // ...then repeatedly every 'each enemy fire rate' seconds

    }

	void Update() {
        rb.velocity = 
            new Vector2(enemyXSpeed, enemyYSpeed * (-1));   // "-1" makes enemies fly down as y value is negative
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Player")
        {                                                   // If there's a collision between enemy and our spaceship...    
            collision.gameObject.                           // ...then perform "Damage" method included in "SpaceshipSteering.cs" file...
                GetComponent<SpaceshipSteering>().Damage(); // ...and immediately kill enemy, performing "Death" method
            Death();
        }
    }

    void Death()
    {
        Instantiate(explosion, transform.position,          // This method destroyes game object which is our enemy...
            Quaternion.identity);                           // ...and creates an explosion effect
        Destroy(gameObject);
    }

    public void Damage()
    {
        enemyHealth--;                                      // This method takes 1 life from enemy 
        if (enemyHealth == 0)
        {                                                   // If enemy's health equals 0...
            Instantiate(explosion, transform.position,      // ...destroy this game object...
                Quaternion.identity);                       // ...and create an explosion effect
            Destroy(gameObject);                            

            PlayerPrefs.SetInt("Score",                     // Also, when enemy dies, player gets points...
            PlayerPrefs.GetInt("Score") + scoreCounter);    // ...(50, 100 or 150 - depends on each kind of enemy)
        }

        }

    void Shoot()
    {
        GameObject enemyBullet =                            // Create a bullet, so enemy can shoot, but bullet has to move down...
            Instantiate(bullet, transform.position,         // ...so perform "ChangeDirection" method in "Bullet.cs" file
            Quaternion.identity);                           
        enemyBullet.
            GetComponent<Bullet>().ChangeDirection();
    }
}
