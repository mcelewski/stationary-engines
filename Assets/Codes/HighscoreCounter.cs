using UnityEngine;
using UnityEngine.UI;                                       // Namespace added in order to control user interface

public class HighscoreCounter : MonoBehaviour {

    void Update()
    {
        GetComponent<Text>().text = 
            PlayerPrefs.GetInt("Highscore") + "";           
    }
}
