using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour {

	Transform objeto;
	Vector3 euler;
	public float g;

	// Use this for initialization
	void Start () {
        objeto = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		euler += Vector3.forward *g* Time.deltaTime;
		objeto.rotation = Quaternion.Euler (euler);
	}
}
