using UnityEngine;

public class SelfDestructionPlayer : MonoBehaviour {

    public float selfDestructionTime;
    public AudioSource ExplosionSound;

    void Start()
    {
        ExplosionFX();                                      // Method "ExplosionFX" is called

        Destroy(gameObject, selfDestructionTime);           // Player's particle system is destroyed after specified time (set in Unity)
    }

    void ExplosionFX()
    {                                                       // Explosion sound is delayed by 1 second because explosion effect...
        ExplosionSound = GetComponent<AudioSource>();       // ...appears after 1 second from the last hit that player can take...
        ExplosionSound.PlayDelayed(1.0f);                   // ...otherwise it would be out of sync (sound played before effect)
    }

}
