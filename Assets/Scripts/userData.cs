using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userData : MonoBehaviour {

    public Text nameTxt;
    public Button fstButton;
    public GameObject panelName;
    

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("userName"))
        {
            return;
        }
        else {
            panelName.SetActive(true);
        }
	}
    private void Update()
    {
        if (nameTxt.text == "")
        {
            fstButton.interactable = false;
        }
        else {
            fstButton.interactable = true;
        }
    }

    public void SetName() {

        string name = nameTxt.text;
        PlayerPrefs.SetString("userName",name);
    }

    public void SetGndr(string gen)
    {
        PlayerPrefs.SetString("userGenero", gen);
    }

}
