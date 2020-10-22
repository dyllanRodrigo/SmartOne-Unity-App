using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class compararRespuesta : MonoBehaviour {

	public GameObject TextoGameObject;
	public Text tpanel;
	GameObject manager;
	public GameObject panelCorrecto;
	public GameObject panelIncorrecto;
	string respuesta;
	public bool fisica;
	private Array_escrito array;
	ResultsInGame results;


	// Use this for initialization
	void Start () {
		manager = this.gameObject;
		manager.tag = "Manager";
		array = gameObject.GetComponent<Array_escrito>();
		respuesta = array.respuestaCorrecta;
		results = FindObjectOfType<ResultsInGame>();
	}

	// Update is called once per frame
	void Update() {
		if (fisica ==true) { 
			if (RespFisica.respuesta.comp == true) { 
				if (RespFisica.respuesta.resultado == "Correcto") { 
					panelCorrecto.SetActive(true);
					TextoGameObject.SetActive(true);
					tpanel.text = "Correcto";
					results.hasWin();
				}else if (RespFisica.respuesta.resultado == "Incorrecto")
				{
					panelIncorrecto.SetActive(true);
					TextoGameObject.SetActive(true);
					tpanel.text = "Incorrecto";
					results.hasLose ();
				}
			}

		}
	}

	public void comparar(Text tboton) {
        FindObjectOfType<TimeManager>().enabled = false;
		if (tboton.text == respuesta)
		{
			Debug.Log("correcto");
			if (fisica == false) { 
				
				panelCorrecto.SetActive(true);
				TextoGameObject.SetActive(true);
				results.hasWin();
			}
			tpanel.text = "Correcto";
			results.hasWin();
		}
		else { 
			Debug.Log("incorrecto");
			if (fisica == false)
			{
				panelIncorrecto.SetActive(true);
				TextoGameObject.SetActive(true);
			}
			tpanel.text = "Incorrecto";
			results.hasLose();
		}

	}

}



