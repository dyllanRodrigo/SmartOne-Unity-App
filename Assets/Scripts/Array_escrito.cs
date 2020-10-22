using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Array_escrito : MonoBehaviour {
	public string[] vectorPosiblesRes= new string[6];
	public string respuestaCorrecta;
	public string textoPregunta;
    int longitud;
	int b;
	int c;
	int d;
	int al;
	public Text texto1;
	public Text texto2;
	public Text texto3;
	public Text texto4;
	public Text texto;
	// Use this for initialization
	void Start () {
        longitud = vectorPosiblesRes.Length;
		b = Random.Range (0, longitud);	
		c = Random.Range (0, longitud);
		d = Random.Range (0, longitud);
		al = Random.Range (1, 4);
		texto.text = "" + textoPregunta;
	}
	
	// Update is called once per frame
	void Update () {

		if(c==b || c==d){	
			c = Random.Range (0,longitud);
		}else{
			if(d==c || d==b){
				d = Random.Range (0,longitud);
			}
		}

		if (al == 1) {
			texto1.text=""+respuestaCorrecta;
			    texto2.text=""+vectorPosiblesRes[b];
			      texto3.text=""+vectorPosiblesRes[c];
			        texto4.text=""+vectorPosiblesRes[d];
		}

		if (al == 2) {
			texto1.text=""+vectorPosiblesRes[d];
		    	texto2.text=""+respuestaCorrecta;
		        	texto3.text=""+vectorPosiblesRes[b];
		        	    texto4.text=""+vectorPosiblesRes[c];
		}

		if (al == 3) {
			texto1.text=""+vectorPosiblesRes[c];
	             texto2.text=""+vectorPosiblesRes[d];
			        texto3.text=""+respuestaCorrecta;
			            texto4.text=""+vectorPosiblesRes[b];
		}

		if (al == 4) {
			texto1.text=""+vectorPosiblesRes[b];
		    	texto2.text=""+vectorPosiblesRes[c];
		        	texto3.text=""+vectorPosiblesRes[d];
			        texto4.text=""+respuestaCorrecta;
		}
	}

}
