using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarNoEscena : MonoBehaviour {

    public void CargarEscena(string nombreNivel) {
        SceneManager.LoadScene(nombreNivel);
    }
}
