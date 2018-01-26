using UnityEngine;

public class Killzone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {                                                       // Whatever game object is reaching the point of killzone...
        Destroy(collision.gameObject);                      // ...(if it's enemy spaceship or bullet), and there's a collision...
    }                                                       // ...between them, destroy this game object after it hits the killzone
}
