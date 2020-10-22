using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caldistancias : MonoBehaviour {
    public Transform inicio;
   
    public GameObject padre;
   public float d;
    float y;
    // Use this for initialization
    void Start() {
        
        y = padre.transform.position.y;

    }
	
	// Update is called once per frame
	void Update () { 
        d = Vector2.Distance(inicio.position, transform.position);
        transform.position = new Vector2(padre.transform.position.x, transform.position.y);
    }

    
   

    
}
