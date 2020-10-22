using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScrollCanvas : MonoBehaviour {

    public bool IniciarEnMovimiento = false;
    public float velocidad = 0f;
    private bool enMovimiento = false;
    private float tiempoInicio = 0f;

    // Use this for initialization
    void Start()
    {
        if (IniciarEnMovimiento)
        {
            PersonajeEmpiezaACorrer();
        }
    }

    void PersonajeHaMuerto()
    {
        enMovimiento = false;
    }

    void PersonajeEmpiezaACorrer()
    {
        enMovimiento = true;
        tiempoInicio = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMovimiento)
        {
           GetComponent<RawImage>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
        }
    }
}
