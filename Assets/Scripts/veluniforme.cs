using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class veluniforme : MonoBehaviour {

    Rigidbody2D velo;

    float time2 = 0f;
    float d;
    float y, x;
    public Transform inicio;
    public TextMesh distancia;
    public Text velocX;
    public Text tiempo;
    public bool velox;
    public float vel;
    public string nivel;
    public bool principal;
    public bool medicion;
    public GameObject panel;
    bool inicia=false;
    public bool CalDist;
	float mostrar;
	// Use this for initialization
	void Start () {
        x = inicio.position.x;
        y = inicio.position.y;
        velo = this.gameObject.GetComponent<Rigidbody2D>();
        inicia = true;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Time.timeScale = 0.1f;
        if (velox == true)
        {
            vel = RespFisica.respuesta.vel;
        }

        if (panel.activeInHierarchy)
        {
          
        }
        else {

            
            if (inicia==true) {
                
				velo.simulated = true;

                if (CalDist == true)
                {
                    inicio.position = new Vector2(x, y);
                    d = Vector2.Distance(inicio.position, transform.position);
                    mostrar = Mathf.Round(d * 1000f) / 1000f;
                    distancia.text = "Distancia = " + mostrar + " m";
                }
                
                if (medicion==true)
                {
                    inicio.position = new Vector2(x, y);
                    d = Vector2.Distance(inicio.position, transform.position);
                    time2 = d / vel;
                    velocX.text = "Velocidad Horizontal = " + vel + " m/s";
					mostrar = Mathf.Round(time2 * 10000f) / 10000f;
                    tiempo.text = "tiempo = " + mostrar + " s";  
					mostrar = Mathf.Round(d * 1000f) / 1000f;
					distancia.text = "Distancia = " + mostrar + " m";

				}
				velo.velocity = new Vector2(vel, GetComponent<Rigidbody2D>().velocity.y);

            }
        }


    }
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Player2")
        {
            velo.simulated = false;
            vel = 0;
            inicia = false;
        }
        if (collision2d.gameObject.tag == "meta")
        {
            
            vel = 0;
            velo.simulated = false;
            inicia = false;
        }
       


        if (principal == true) { 
        if (collision2d.gameObject.tag == "final")
        {
                medicion = false;
              
            StartCoroutine("waitThreeSeconds"); 		
            

        }
        else
        {
            if (collision2d.gameObject.tag == "caida")
            {
                    medicion = false;
                    
                StartCoroutine("waitThreeSeconds");
                
            }
           
        }
        }
    }

    IEnumerator waitThreeSeconds()
    {
        inicia = false;
        velo.simulated = false;
        yield return new WaitForSeconds(1);
        RespFisica.respuesta.comp = true;

        SceneManager.LoadScene(nivel);
    }
}
