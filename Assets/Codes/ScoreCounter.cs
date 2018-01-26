using UnityEngine;
using UnityEngine.UI;                                       // Namespace added in order to control user interface

public class ScoreCounter : MonoBehaviour {

	void Update ()
    {
        GetComponent<Text>().text = 
            PlayerPrefs.GetInt("Score") + "";		
	}
}
