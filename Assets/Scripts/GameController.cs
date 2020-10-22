using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public GameObject gameOverText;
    public GameObject gameOverPanel;
 
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    public Slider energySlider;
    public Slider CalcSlider;
    private int score,calc;
    public Text scoreText;
    public Text CalcText;
    public GameObject panelHundred;
    bool msgShown = false;

    private void Awake()
    {
        if(GameController.instance == null)
        {
            GameController.instance = this;
        }else if(GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no debería pasar.");
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("userEnergy") <= 0)
        {
        PlayerPrefs.SetInt("userEnergy",0);
        calc = PlayerPrefs.GetInt("calculatorINT");
            CalcText.text = calc.ToString() + "/12";
        }
        else {  
            score = PlayerPrefs.GetInt("userEnergy");
            calc = PlayerPrefs.GetInt("calculatorINT");
          
            scoreText.text = score.ToString() + "/100";
            CalcText.text = calc.ToString() + "/12";
        }
    }

    private void Update()
    {
        energySlider.value = score;
        CalcSlider.value = calc;
        if (PlayerPrefs.GetInt("userEnergy") >= 100 && msgShown == false) {
            panelHundred.SetActive(true);
            StartCoroutine(TimeEspera(2.5f));
        }
    }

    IEnumerator TimeEspera(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        panelHundred.SetActive(false);
        msgShown = true;
    }


    public void BirdScored()
    {
        
            if (gameOver || score >= 100)
            {
               
                SoundSystem.instance.PlayCoin();
                return;
            }
            else { 
            
        score = score + 5;
        PlayerPrefs.SetInt("userEnergy",score);
        scoreText.text = score.ToString() + "/100";
        SoundSystem.instance.PlayCoin();
            }  
    }
    public void Calculator()
    {
            if (gameOver || calc >= 12) { 
            SoundSystem.instance.PlayCoin();
            return;
        }
        else { 
        calc++;       
            SoundSystem.instance.PlayCoin();
            PlayerPrefs.SetInt("calculatorINT", calc);
            CalcText.text = calc.ToString() + "/12";
        }


    }
    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOverPanel.SetActive(true);
        gameOver = true;
    }

    private void OnDestroy()
    {
        if(GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
