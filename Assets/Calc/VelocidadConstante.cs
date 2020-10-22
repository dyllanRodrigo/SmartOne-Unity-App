using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadConstante : MonoBehaviour {

    public Vector2 velocidad;
    Rigidbody2D obj;
	// Use this for initialization
	void Start () {
        obj = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        obj.velocity = velocidad;       
	}
}
