using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;                          // Namespace added in order to control scenes included in project

public class DeathScreen : MonoBehaviour {

    GameObject player;
    bool isDeath = false;

	void Start()
    {
        player = GameObject.                                // It returns a game object with "Player" tag set...
            FindGameObjectWithTag("Player");                // ...and this object has to be active
	}
	

	void Update()
    {                                                       // If the game object (in this case player's spaceship) is destroyed...
        if (player == null && !isDeath)                     // ...(as "null" value means there's no game object in a game)...
            GameOver();                                     // ...and "isDeath" value is logically negated
    }                                                       // ...(so its value is set to "true"), then perform "GameOver" method

    void GameOver()
    {
        isDeath = true;                                     // In this method "isDeath" has to be set to "true" value

        StartCoroutine(LoadGameOver());                     // If "GameOver" method is called, it starts "LoadGameOver" coroutine

        if (PlayerPrefs.GetInt("Score") >                   // If score value is greater than actual highscore...
            PlayerPrefs.GetInt("Highscore"))                
            PlayerPrefs.SetInt("Highscore",                 // ...set this score as new highscore
                PlayerPrefs.GetInt("Score"));
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(4.5f);              // It loads scene where score and highscore is shown...
        SceneManager.LoadScene(2);                          // ...but by yield value, it loads it after 4.5 seconds
    }
}
