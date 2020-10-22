using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
	public GameObject poder;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (this.gameObject.tag == "power")
            {
            GameController.instance.BirdScored();
            }
            else
            {
                GameController.instance.Calculator();
            }
            Destroy (poder);
			this.gameObject.GetComponent<BoxCollider2D> ().enabled=false;
            StartCoroutine(TimeEspera());
        }
    }

    IEnumerator TimeEspera()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }

}
