using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{

    public MovingPlatform movingPlat;

    public GameObject platform;
    public float moveSpeed;
    public Transform currentPoint;

	public Button botonSig;
	public Button botonAnt;

    public Transform[] points;

    public string[] names;
    string actualName;
    public Text theNameTxt;

    //Info//////////////////////////////////////////////
    public string[] topic;
    string actualTopic;
    public Text theTopicTxt;

    public string[] topicTitle;
    string actualTopicTitle;
    public Text theTopicTxtTitle;

    public Sprite[] topicImageList;
    Sprite actualTopicImage;
    public Image theTopicImage;

    //Info//////////////////////////////////////////////
    string LevelToLoad;
    public int pointSelection;
    int topicRndInt;

    // Use this for initialization
    void Start()
    {
		currentPoint = points [pointSelection];
        movingPlat = gameObject.GetComponent<MovingPlatform>();
        topicRndInt = Random.Range(0, topic.Length);
        theTopicTxt.text = topic[topicRndInt];
        theTopicTxtTitle.text = topicTitle[topicRndInt];
        theTopicImage.sprite = topicImageList[topicRndInt];
    }

    // Update is called once per frame
    void Update()
    {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);


            currentPoint = points[pointSelection];
        if (names.Length == points.Length)
        {
            actualName = names[pointSelection];
            theNameTxt.text = actualName;
            LevelToLoad = actualName + "_" + "LevelSelect"; 
        }
        else {
            Debug.LogError("Incorrect data asignment into array");
        }

		if (pointSelection == points.Length-1) {
			botonSig.interactable = false;
		} else {
			botonSig.interactable = true;
		}


		if (pointSelection == 0) {
			botonAnt.interactable = false;
		} else {
			botonAnt.interactable = true;
		}
        
    }

    public void CargarEscenaLevelSelect()
    {    
        StartCoroutine(TimeEspera());
    }

    IEnumerator TimeEspera()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(LevelToLoad);
    }


    public void move(int m){
		
		pointSelection = m-1;
	}

	public void siguiente(){
			pointSelection++;
	}

	public void anterior(){
			pointSelection--;
	}
}

