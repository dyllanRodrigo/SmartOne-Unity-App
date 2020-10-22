using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsInGame : MonoBehaviour
{

    public int time;
    public int thisScore;
    public float porcent;

    private int NivelesEnTotal = 60;//numero de niveles en total
    public int CurrentLevel;
    public TimeManager timeManager;
    public bool haGanado;

    public string planetName;

    int NextLevel;

    public int stars;
    public int hasplay = 0;
    public Text starsText;

    public Slider EnergySlider;
    public int energy;
    public GameObject panelGO;

    public int forOneStar;
    public int forTwoStar;
    public int forThreeStar;

    void Start()
    {
        CheckCurrentLevel();
        //  PlayerPrefs.SetInt("Level2", 1); //coloca datos al finalizar el nivel para guarar como terminado y desbloquear siguiente
        // PlayerPrefs.SetInt("Level1_score", score);
        NextLevel = CurrentLevel + 1;

        if (PlayerPrefs.HasKey("userEnergy") == false) {
            PlayerPrefs.SetInt("userEnergy", 100);
        }
        else
        {
            energy = PlayerPrefs.GetInt("userEnergy");
        }

        if (PlayerPrefs.GetInt("userEnergy") <= 0) {
            panelGO.SetActive(true);
        }

        EnergySlider.value =  PlayerPrefs.GetInt("userEnergy");
        porcent = PlayerPrefs.GetFloat(planetName + "_porcent");
        // PlayerPrefs.DeleteAll();
    }


    void Update()
    {
        time = timeManager.tiempoActual;
        stars = PlayerPrefs.GetInt("totalStars");
        starsText.text = stars.ToString();

        thisScore = PlayerPrefs.GetInt("Level" + planetName + "_" + CurrentLevel.ToString() + "_score");

        if (PlayerPrefs.GetFloat(planetName + "_porcent") < (CurrentLevel + 0.0f) / (NivelesEnTotal + 0.0f) * 100) {
         PlayerPrefs.SetFloat(planetName + "_porcent", (CurrentLevel + 0.0f) / (NivelesEnTotal + 0.0f) * 100);
        }
        
        if (PlayerPrefs.HasKey("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay"))
        {
            hasplay = 1;
        }
        else { hasplay = 0; }

        EnergySlider.value = energy;
    }

    void CheckCurrentLevel()
    {
        for (int i = 1; i < NivelesEnTotal; i++)
        {
            if (Application.loadedLevelName == "Level" + planetName + "_" + i)
            {
                CurrentLevel = i;
            }
        }

    }
    void SaveMyGame(int score)
    {

        if (NextLevel < NivelesEnTotal)
        {
            PlayerPrefs.SetInt("Level" + planetName + "_" + NextLevel.ToString(), 1);//Desbloqueo del siguiente nivel
            PlayerPrefs.SetInt("Level" + planetName + "_" + CurrentLevel.ToString() + "_score", score);
        }
    }

    public void hasWin()
    {
            haGanado = true;
            PlayerPrefs.SetInt("Level" + planetName + "_" + "2", 1);
        //   PlayerPrefs.SetInt("Level" + planetName + "_" + "1" + "_score", thisScore);
           
        if (time <= forOneStar && PlayerPrefs.HasKey("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay") == false)
        {
           // stars += 1;
            PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars") + 1);
            SaveMyGame(1);
           // PlayerPrefs.SetInt("totalStars",stars);
            PlayerPrefs.SetInt("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay",1);
        }
        else if (time >= forOneStar && time <= forTwoStar && PlayerPrefs.HasKey("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay") == false)
        {
            // stars += 2;
            PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars") + 2);
            SaveMyGame(2);
            //PlayerPrefs.SetInt("totalStars", stars);
            PlayerPrefs.SetInt("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay", 1);
        }
        else if (time >= forTwoStar && time <= forThreeStar && PlayerPrefs.HasKey("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay") == false) {
           // stars += 3;
            SaveMyGame(3);
            PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars") + 3);
            // PlayerPrefs.SetInt("totalStars", stars);
            PlayerPrefs.SetInt("Level" + planetName + "_" + CurrentLevel.ToString() + "hasPlay", 1);
        }

    }

    public void hasLose() {

        if (energy > 0)
        {
            haGanado = false;
            energy -= 20;
            PlayerPrefs.SetInt("userEnergy", energy);
        }
        else {
            Debug.Log("Juego Terminado");
            panelGO.SetActive(true);
        }
        }

    public void LoadNextLevel()
    {
        StartCoroutine(NextLevelD());
    }

    public void ResetLevel()
    {
        StartCoroutine(Reset());
    }

    public void toMenu(string level)
    {
        StartCoroutine(MenuScene(level));
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level" + planetName + "_" + CurrentLevel);
    }

    IEnumerator NextLevelD()
    {
        yield return new WaitForSeconds(0.5f);
        if (NextLevel < 0 || NextLevel >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Cant Load num" + NextLevel + "SceneManager Only has" + SceneManager.sceneCountInBuildSettings + "scenes in BLTSettings");
        }
        SceneManager.LoadScene("Level" + planetName + "_" + NextLevel.ToString());
    }

    IEnumerator MenuScene(string menu)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(menu);
    }

}
