using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelManagerNew : MonoBehaviour {

    [System.Serializable]

    public class Level {
        public string LevelText;
        public int Unlocked;
        public bool IsInteractable;
    }

    public List<Level> LevelList;
    public GameObject LevelButton;
    public Transform Spacer;
    public string planetName;

    // Use this for initialization
    void Start() {
       //DeleteAll();
        FillList();
    }

    void FillList() {
        foreach (var Level in LevelList) {
            GameObject newButton = Instantiate(LevelButton) as GameObject;

            LevelButton button = newButton.GetComponent<LevelButton>();

            button.LevelText.text = Level.LevelText;

           
            //colocar solo el numero de nivel 1,2,3

            if (PlayerPrefs.GetInt("Level" + planetName + "_" + button.LevelText.text) == 1) {
                Level.Unlocked = 1;
                Level.IsInteractable = true;
            }


            button.Unlocked = Level.Unlocked;
            button.GetComponent<Button>().interactable = Level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(TimeEspera(button.LevelText.text)));
            button.GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<Fading>().GetComponent<Fading>().BeginFadeFunc());


            if (PlayerPrefs.GetInt("Level" + planetName + "_" + button.LevelText.text + "_score") == 1){
                button.star1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + planetName + "_" + button.LevelText.text + "_score") == 2)
            {
                button.star1.SetActive(true);
                button.star2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level" + planetName + "_" + button.LevelText.text + "_score") == 3)
            {
                button.star1.SetActive(true);
                button.star2.SetActive(true);
                button.star3.SetActive(true);
            }



            newButton.transform.SetParent(Spacer, false);
        
        }
        SaveAll();
    }


    void SaveAll() {

        //   if (PlayerPrefs.HasKey("Level1"))
        // {
        //    return;
        //}
        //else
        {

            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject buttons in allButtons)
            {

                LevelButton button = buttons.GetComponent<LevelButton>();
                PlayerPrefs.SetInt("Level" + planetName + "_" + button.LevelText.text, button.Unlocked);
            }
        }
    }

    void DeleteAll(){
        PlayerPrefs.DeleteAll();
    }

    IEnumerator TimeEspera(string nameLvl)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level" + planetName + "_" + nameLvl);
    }

}

