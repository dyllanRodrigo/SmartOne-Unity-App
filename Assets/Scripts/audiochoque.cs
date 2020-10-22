using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiochoque : MonoBehaviour {
    public AudioClip Sonido = null;
    public float Volumen = 5.0f;
    protected Transform Posicion = null;
    public bool desaceleracion;
    // Use this for initialization
    void Start() {
        Posicion = transform;
    }

    // Update is called once per frame
    void Update() {

    }
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (desaceleracion == true) {
            if (collision2d.gameObject.tag != "meta")
            {
                if (Sonido) AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
            }
        }
        else
        {
            if (Sonido) AudioSource.PlayClipAtPoint(Sonido, Posicion.position, Volumen);
        }
    }
    }
