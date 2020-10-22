using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFade1 : MonoBehaviour {

     string nombreEscena;

   public void LoadScene(string scene)
    {
        nombreEscena = scene;
            gameObject.GetComponent<Fading>().BeginFadeFunc();
            StartCoroutine(TimeEspera(1f));  
    }

    IEnumerator TimeEspera(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nombreEscena);
    }
}
