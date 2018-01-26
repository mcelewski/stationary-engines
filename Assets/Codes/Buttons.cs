using UnityEngine;
using UnityEngine.SceneManagement;                          // Namespace added in order to control scenes included in project

public class Buttons : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();                                 // If player hits "Exit" button, application quits
    }

    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);                     // If player hits "Start" button, set score value to "0"...
        SceneManager.LoadScene(1);                          // ...and load scene where game is included
    }
}
