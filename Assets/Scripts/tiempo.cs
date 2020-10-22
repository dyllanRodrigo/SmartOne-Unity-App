using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tiempo : MonoBehaviour {
   
    public float startingTime;
    public Text theText;
    public int minTime;
    public int tiempoActual;

    public GameObject panel;
	
	// Use this for initialization
	void Start () {
		
        theText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startingTime >= 0)
        {
            startingTime -= Time.deltaTime;
        }
       

        theText.text = "" + Mathf.Round(startingTime);
        tiempoActual = Mathf.RoundToInt(startingTime);



        if (tiempoActual <= minTime && tiempoActual > 1)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }

        if (startingTime <= 0)
        {

            panel.SetActive(false);

        }

    }


  
}
