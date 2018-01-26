using UnityEngine;

public class SelfDestruction : MonoBehaviour {

    public float selfDestructionTime;
    public AudioSource ExplosionSound;

    void Start()
    {
        ExplosionFX();                                      // Method "ExplosionFX" is called

        Destroy(gameObject, selfDestructionTime);           // Enemy's particle system is destroyed after specified time (set in Unity)
    }

    void ExplosionFX()
    {
        ExplosionSound = GetComponent<AudioSource>();       
        ExplosionSound.Play();
    }

}

