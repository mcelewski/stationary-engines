using UnityEngine;

public class EnemiesSpawningBorders : MonoBehaviour {

    public float rate = 2;
    public GameObject[] enemies;
    public int waves = 1;

    void Start()
    {
        InvokeRepeating(methodName: "EnemySpawning",        // Invokes "EnemySpawning" method in 2 seconds from launching...
            time: rate, repeatRate: rate);                  // ...then repeatedly every 2 seconds
    }

    void EnemySpawning()
    {

        for (int i = 0; i < waves; i++)
        Instantiate(enemies                                 // Spawn random enemy (from 3 different models)...
            [(int)Random.Range(0, enemies.Length)],         // ...in this case, spawn the enemy...
            new Vector2(Random.Range(-15, 0), 13),          // ...at x value: anywhere at -15 to 0 range and at y value: at 13...
            Quaternion.identity);                           // ...so that they appear above game screen
    }
}
