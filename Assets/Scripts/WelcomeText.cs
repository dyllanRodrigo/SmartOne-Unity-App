using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeText : MonoBehaviour {

    Text yhisText;
    public string firstTextM;
    public string firstTextF;
    public string secondText;

	// Use this for initialization
	void Start () {
        yhisText = gameObject.GetComponent<Text>();
        if (PlayerPrefs.HasKey("userName") && PlayerPrefs.GetString("userGenero") == "Mujer")
        {
            yhisText.text = firstTextF + " " + PlayerPrefs.GetString("userName") + " " + secondText;
        }
        else
        {
            yhisText.text = firstTextM + " " + PlayerPrefs.GetString("userName") + " " + secondText;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
