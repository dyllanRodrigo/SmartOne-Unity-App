using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeGesture : MonoBehaviour
{
    public float minSwipeDistY;
    public float minSwipeDistX;

    private Vector2 startPos;

    MovingPlatform moving;
    public Button botonSig;
    public Button botonAnt;

    void Start(){
        moving = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingPlatform>();
    }

    void Update()
    {


        if (Input.touchCount > 0) {

            Touch touch = Input.touches[0];

            switch (touch.phase){

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;

                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY) {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                        {
                            Debug.Log("UP");
                        }

                        //Jump ();

                        else if (swipeValue < 0)//down swipe
                        {
                            Debug.Log("DOWN");
                        }

                        //Shrink ();

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX) {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0 && botonAnt.interactable)//right swipe
                        {
                            moving.anterior();
                        }

                        //MoveRight ();

                        else if (swipeValue < 0 && botonSig.interactable)//left swipe
                        {
                            moving.siguiente();
                        }
                        //MoveLeft ();

                    }
                    break;
            }
        }
    }

}