using System.Collections;
using UnityEngine;

public class SpaceshipSteering : MonoBehaviour {

    GameObject bullet1, bullet2;
    public GameObject bullet;
    public GameObject explosion;
    public Sprite player5Lives;
    public Sprite player4Lives;
    public Sprite player3Lives;
    public Sprite player2Lives;
    public Sprite player1Life;
    public AudioSource LaserSound;

    Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    [SerializeField] private int playerHealth = 5;
    [SerializeField] private float shootRate = 0.2f;
    float nextShoot = 0.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet1 = transform.Find("Bullet 1").gameObject;    // It finds and assigns bullet on the left side 
        bullet2 = transform.Find("Bullet 2").gameObject;    // It finds and assigns bullet on the right side
    }

    void Start ()
    {
        PlayerPrefs.SetInt("Health", playerHealth);         // At the beginning of the game, set player's health value to 5
    }
	
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");     
        float vertical = Input.GetAxis("Vertical");
        HorizontalMovement(horizontal);
        VerticalMovement(vertical);

        if (Input.GetKey(KeyCode.Space)
            && Time.time > nextShoot)
            Shoot();
    }

    void HorizontalMovement (float horizontal)
    {
        rb.velocity = new Vector2
            (horizontal * movementSpeed, rb.velocity.y);
    }

    void VerticalMovement(float vertical)
    {
        rb.velocity = new Vector2
            (rb.velocity.x, vertical * movementSpeed);
    }

    public void Damage()
    {
        playerHealth--;                                     // This method takes 1 life from player 
        PlayerPrefs.SetInt("Health", playerHealth);
        StartCoroutine(DamageFlashing());                   // When player is hit, it is shown by quick flashing (set in coroutine)
        if (playerHealth == 5)
        {                                                   // If enemy's health equals 5...
            gameObject.                                     // ...set sprite that should be shown when player has 5 lives
                GetComponent<SpriteRenderer>().sprite
                = player5Lives;

            shootRate = 0.2f;                               // Set shoot rate to 0.2 seconds
            movementSpeed = 20.0f;                          // Set speed to 20 (units)
        }
        if (playerHealth == 4)
        {                                                   // If enemy's health equals 4...
            gameObject.                                     // ...set sprite that should be shown when player has 4 lives
                GetComponent<SpriteRenderer>().sprite 
                = player4Lives;

            shootRate = 0.2f;                               // Set shoot rate to 0.2 seconds
            movementSpeed = 17.5f;                          // Set speed to 17.5 (units)
        }
        if (playerHealth == 3)
        {                                                   // If enemy's health equals 3...
            gameObject.                                     // ...set sprite that should be shown when player has 3 lives
                GetComponent<SpriteRenderer>().sprite 
                = player3Lives;

            shootRate = 0.2f;                               // Set shoot rate to 0.2 seconds
            movementSpeed = 15.0f;                          // Set speed to 15 (units)
        }
        if (playerHealth == 2)
        {                                                   // If enemy's health equals 2...
            gameObject.                                     // ...set sprite that should be shown when player has 2 lives
                GetComponent<SpriteRenderer>().sprite 
                = player2Lives;

            shootRate = 0.3f;                               // Set shoot rate to 0.3 seconds
            movementSpeed = 12.5f;                          // Set speed to 12.5 (units)
        }
        if (playerHealth == 1)
        {                                                   // If enemy's health equals 1...
            gameObject.                                     // ...set sprite that should be shown when player has 1 life
                GetComponent<SpriteRenderer>().sprite 
                = player1Life;

            shootRate = 0.4f;                               // Set shoot rate to 0.4 seconds
            movementSpeed = 7.5f;                           // Set speed to 7.5 (units)
        }
        if (playerHealth == 0)
        {                                                   // Set shoot rate to 10 seconds (player can't shoot any bullet at this time...
            shootRate = 10.0f;                              // ...because his spaceship destroys in 1 second anyway)                
            movementSpeed = 0.0f;                           // Set speed to 0 (player can't move)
            Destroy(gameObject, 1.0f);                      // Destroy this game object after 1 second...
            Instantiate(explosion, transform.position,      // ...and create an explosion effect
                Quaternion.identity);                       
        }
    }

    IEnumerator DamageFlashing()
    {
        for (int i = 0; i < 5; i++)                         // By this "for" loop, player's damage is shown quickly 5 times
        {
            GetComponent<SpriteRenderer>().color            // Change sprite values, so player's spaceship is invisible for 0.1 seconds
                = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.1f);   
            GetComponent<SpriteRenderer>().color            // Change sprite values, so player's spaceship is visible for 0.1 seconds
                = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bullet1.transform.position,     // Create a bullet on the left side, so player can shoot
            Quaternion.identity);
        Instantiate(bullet, bullet2.transform.position,     // Create a bullet on the right side, so player can shoot
            Quaternion.identity);
        nextShoot = Time.time + shootRate;                  // Shooting interval
        LaserSound = GetComponent<AudioSource>();
        LaserSound.Play();
    }

}
