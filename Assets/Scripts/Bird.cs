using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 200f;
    private ColumnPool columnas;

    private RotateBird rotateBird;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
    }

    // Use this for initialization
    private void Start () {
        columnas = FindObjectOfType<ColumnPool>();
        startAll(false);
	}

    void startAll(bool hasTouch) {
        if (hasTouch) {
            columnas.enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Update is called once per frame
    private void Update () {
        if (isDead) return;
        
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Flap");
            SoundSystem.instance.PlayFlap();
            startAll(true);
        }        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        rotateBird.enabled = false;
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
    }
}
