using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacioncaida : MonoBehaviour {
    float seg;
    public float restarseg;
    public float timeAnim;
    public GameObject panel;
    bool inicia=true;
    Animator objeto;
    // Use this for initialization
    void Start() {
        objeto = this.gameObject.GetComponent<Animator>();
        seg = RespFisica.respuesta.vel;
	}
	
	// Update is called once per frame
	void Update () {
        if (panel.activeInHierarchy)
        {

        }
        else
        {
            if (inicia == true) { 
            StartCoroutine("waitThreeSeconds");
                inicia = false;
            }
        }
	}

    IEnumerator waitThreeSeconds()
    {

        yield return new WaitForSeconds(seg - restarseg);
        objeto.enabled = true;
        StartCoroutine("animacion");
    }

    IEnumerator animacion()
    {

        yield return new WaitForSeconds(timeAnim);
        objeto.enabled = false;
    }
}
