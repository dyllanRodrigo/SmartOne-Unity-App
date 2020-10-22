using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFlapToRestart : MonoBehaviour {

    public GameObject flapToRestart;
    public int delay = 1;

	void OnEnable () {
        Invoke("EnableFlapToRestart", delay);	
	}

    void EnableFlapToRestart()
    {
        flapToRestart.SetActive(true);
    }

}
