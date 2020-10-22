using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class desactivarOBJ : MonoBehaviour {

    public GameObject objeto;
    public string parametro;

    // Use this for initialization
    void Start() {
    }

    public void desactivar() {
      objeto.GetComponent<Animator>().SetBool(parametro,true);
    }
    public void activar()
    {
        objeto.GetComponent<Animator>().SetBool(parametro, false);
    }
}
