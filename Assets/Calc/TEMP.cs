using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMP : MonoBehaviour {
    public string nombreEscena;

    void Update(){
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }

}
