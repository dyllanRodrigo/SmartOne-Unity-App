using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundKeeper : MonoBehaviour {
    public int min;
    public int max;
    public string layer;

	// Use this for initialization
	void Awake () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(layer);
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        if (SceneManager.GetActiveScene().buildIndex >= min && SceneManager.GetActiveScene().buildIndex <= max)
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
