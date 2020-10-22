using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startFunctions : MonoBehaviour {

    public Image ex;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("volume") == false) {
            PlayerPrefs.SetFloat("volume", 1);
        }
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        if (AudioListener.volume == 1)
        {
            ex.enabled = false;
        }
        else {
            ex.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void QutarSonido() {
        if (PlayerPrefs.GetFloat("volume") == 1)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetFloat("volume", 0);
            ex.enabled = true;
        }
        else {
            AudioListener.volume = 1;
            PlayerPrefs.SetFloat("volume", 1);
            ex.enabled = false;
        }
    }


    public void Url(string url) {
        Application.OpenURL(url);
    }
}
