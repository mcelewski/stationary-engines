using UnityEngine;
using UnityEngine.UI;                                       // Namespace added in order to control user interface

public class HealthCounter : MonoBehaviour {

    void Update ()
    {
        GetComponent<Text>().text = 
            PlayerPrefs.GetInt("Health") + "";
    }
}
