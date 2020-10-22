using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Velvariada : MonoBehaviour {
    Rigidbody2D rueda;
    public string nivel;
    public Transform inicio;
    public GameObject panel;
    public Text velf, tiempo, ace;
    public TextMesh distancia;
    public float aceleracion,Vi;
    public bool acel;
    float dist,time,redon;
    public bool Velinicial;
    public bool medicion;
    public bool principal;
    float Vf;
    float x;
    bool inicia=true;
	// Use this for initialization
	void Start () {
        x = inicio.position.x;
        rueda =this.gameObject.GetComponent<Rigidbody2D>();
        rueda.velocity = new Vector2(Vi, 0f);
        Vf = Vi;
    }
	
	// Update is called once per frame
	void Update () {
        inicio.position = new Vector2(x, inicio.position.y);
        if (acel == true)
        {
            aceleracion = RespFisica.respuesta.vel;
            acel = false;
           
        }
        if (Velinicial == true)
        {
            Vi = RespFisica.respuesta.vel;
            Velinicial = false;
           
        }
        if (rueda.simulated == false)
        {
            Physics2D.gravity = new Vector2(aceleracion, -9.81f);
        }
        if (panel.activeInHierarchy)
        {

        }
        else { 
            
        if (inicia == true)
        {
                rueda.simulated = true;
            if (rueda.velocity.x>=0)
            {
                rueda.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

                if (medicion == true)
                {
                    
                   
                    Vf = rueda.velocity.x;
                        
                            dist = Vector2.Distance(inicio.position, transform.position);
                            time = (2f*dist)/(Vi+Vf);
                        
                        redon = Mathf.Round(dist * 100f) / 100f;
                    distancia.text = "Distancia = " + redon +" m";
                    redon = Mathf.Round(time * 100f) / 100f;
                    tiempo.text = "Tiempo = " + redon +" s";
                    redon = Mathf.Round(Vf * 100f) / 100f;
                    velf.text = "Velocidad horizontal = " + redon + " m/s";
                    
                        ace.text ="Aceleracion = "+ aceleracion + "m/s²";
                }
            }
            else
            {
                
                aceleracion = 0f; 
               
                inicia = false;
                    StartCoroutine("waitThreeSeconds");
                }   
        }
        }


    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        
        if (collision2d.gameObject.tag == "Player2")
        {
            rueda.simulated = false;
            medicion = false;
        }
        if (principal == true)
        {
            if (rueda.velocity.x <= 1f && collision2d.gameObject.tag == "meta")
            {
                

                StartCoroutine("waitThreeSeconds");
            }

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

        rueda.simulated = false;
        yield return new WaitForSeconds(1);
        RespFisica.respuesta.comp = true;
        SceneManager.LoadScene(nivel);
    }
}
