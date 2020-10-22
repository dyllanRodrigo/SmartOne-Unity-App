using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarColumn : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Column"))
		{
			Destroy (this.gameObject);

		}
	}

}