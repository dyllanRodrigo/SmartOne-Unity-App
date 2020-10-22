using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTimer : MonoBehaviour {

    public float TiempoEspera;
    public GameObject objeto;

    // Use this for initialization
    void Start () {
        StartCoroutine(TimeEspera());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TimeEspera(){
        yield return new WaitForSeconds(TiempoEspera);
        objeto.SetActive(true);
    }



}
