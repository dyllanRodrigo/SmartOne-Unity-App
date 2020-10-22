using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculatorCounter : MonoBehaviour {

    public GameObject panelCalc;
    public desactivarOBJ desact;
    public GameObject panelMsg;

    private Text thisText;
    int val;
	// Use this for initialization
	void Start () {
        thisText = gameObject.GetComponent<Text>();
        if (PlayerPrefs.HasKey("calculatorINT"))
        {
            return;
        }
        else {
            PlayerPrefs.SetInt("calculatorINT",12);
        }
    }
	
	// Update is called once per frame
	void Update () {
        val = PlayerPrefs.GetInt("calculatorINT");
        thisText.text = val.ToString();
    }

    public void useOne() {
        if (val != 0)
        {
            val--;
            PlayerPrefs.SetInt("calculatorINT", val);
            panelCalc.SetActive(true);
            desact.activar();
        }
        else {
            panelMsg.SetActive(true);
            return;
        }
    }
}
