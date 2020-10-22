using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidocamion : MonoBehaviour {
    public AudioSource motor;
    Rigidbody2D objeto;
    bool final;
	// Use this for initialization
	void Start () {
	objeto=this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(objeto.simulated==true && motor.mute == true)
        {
            motor.mute = false;
            final=true;
        }
        if (objeto.simulated == true && motor.mute!=true && final==false) 
        {
            motor.pitch = 1.5f;
            final = true;
        }
        if (objeto.simulated == false && final == true && motor.pitch>=0f)
        {
            motor.pitch = motor.pitch-0.03f;
            
        }
    }
}
