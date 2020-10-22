using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acsonido : MonoBehaviour {
    public AudioSource sonido;
    Rigidbody2D objeto;
    bool inicia=true;
	// Use this for initialization
	void Start () {
        objeto = this.gameObject.GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {
        if (objeto.simulated==true && inicia==true)
        {
            sonido.mute = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        sonido.mute = true;
        inicia = false;
    }
    }
