using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nt32Instance : MonoBehaviour {

    public GameObject objetoVolador;
    private GameObject InstObj;

    private IEnumerator coroutine;
    public float rangoMin;
    public float rangoMax;

    float TiempoEspera;
    public Vector2 CustVelocidad;

    // Use this for initialization
    void Start()
    {
        TiempoEspera = Random.Range(rangoMin, rangoMax);
        coroutine = EsperarYDisparar(TiempoEspera);
        StartCoroutine(coroutine);
    }


    // every x seconds perform the print()
    private IEnumerator EsperarYDisparar(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            InstObj = (GameObject)Instantiate(objetoVolador, gameObject.transform.position, gameObject.transform.rotation);
            InstObj.GetComponent<VelocidadConstante>().velocidad = CustVelocidad;
            Destroy(InstObj, 3f);
        }
    }


}
