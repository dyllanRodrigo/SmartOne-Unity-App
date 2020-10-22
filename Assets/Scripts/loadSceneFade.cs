using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneFade : MonoBehaviour {

    public string nombreEscena;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.GetComponent<Fading>().BeginFadeFunc();
            StartCoroutine(TimeEspera(1f));
        }
    }

    IEnumerator TimeEspera(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nombreEscena);
    }
}
