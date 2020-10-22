using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class porcentajeNivel : MonoBehaviour {

    Text theText;
    float porcent;
    public Text energy;
    public Text stars;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("userEnergy") < 0) {
            PlayerPrefs.SetInt("userEnergy", 0);
        }
        theText = gameObject.GetComponent<Text>();
        porcent = PlayerPrefs.GetFloat(FindObjectOfType<LevelManagerNew>().planetName + "_porcent");
        
        theText.text = System.Math.Round(porcent).ToString() + "%";
        energy.text = PlayerPrefs.GetInt("userEnergy").ToString() + " / " + "100";
        stars.text = PlayerPrefs.GetInt("totalStars").ToString();
    }
}


