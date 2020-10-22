using UnityEngine;
using System.Collections;

public class FxKeeper : MonoBehaviour {

    public AudioClip clip;
    public GameObject startButtonFX;
    GameObject objeto;

    // Use this for initialization

    public void Crear() {
       objeto = Instantiate(startButtonFX) as GameObject;
        DontDestroyOnLoad(objeto);
        Destroy(objeto, clip.length);
    }

    void Update() {
        
    }
}

