using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour {

    public float startingTime;
    public Text theText;
    public int minTime;
    public int tiempoActual;
	public bool fisica;
    public GameObject timeOutScreen;
    public Animator animacionCalc;
    bool haslose = false;
	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startingTime >= 0){
            startingTime -= Time.deltaTime;
        }

        theText.text = "" + Mathf.Round (startingTime);
        tiempoActual = Mathf.RoundToInt(startingTime);



        if (tiempoActual <= minTime && tiempoActual > 1) {
            gameObject.GetComponent<Animator>().enabled = true;
        }

        if (tiempoActual <= 0 && haslose == false)
        {
            haslose = true;
            ActivarTimeOut();
            FindObjectOfType<ResultsInGame>().hasLose();
            animacionCalc.SetBool("desactivar", true);
            gameObject.GetComponent<Animator>().enabled = false;
			if(fisica==true){
				Destroy (RespFisica.respuesta.gameObject);
			}
        }
    }


    void ActivarTimeOut()
    {
        timeOutScreen.SetActive(true);
    }
}
