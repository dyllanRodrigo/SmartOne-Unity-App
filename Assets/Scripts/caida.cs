using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class caida : MonoBehaviour {
    Rigidbody2D rueda;
    public Animator pal;
    public Transform inicio;
    public Text tiempo;
    public Text altura;
    public Text Vfy;
    public GameObject panel;
    public string nivel;
    public float velY;
    float seg;
    float h;
    float x, y;
    float t=3f;
    float t2=0f;
    float vo;
	float mostrar;
    public float vf;
    bool inicia;
    public bool Vi;
    public bool espera;
    public bool principal;
    public bool medicion;
   

    
    // Use this for initialization
    void Start() {
        x = inicio.position.x;
        y = inicio.position.y;
        rueda = this.gameObject.GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update() {
		
        if (espera == true && panel!=panel.activeInHierarchy)
        {
            seg = RespFisica.respuesta.vel;
            StartCoroutine("waitThreeSeconds");		
			vo = velY;
            espera = false;
            
        }
        if (Vi == true && panel.activeInHierarchy)
        {

            velY = RespFisica.respuesta.vel;
            vo = velY;
            Vi = false;
            inicia = true;
            
        }
        if (panel.activeInHierarchy)
        {
            
        }
        else
        {
            if (inicia == true)
            {

                
                if (medicion == true)
                {
                    inicio.position = new Vector2(x,y);
                    h = Vector2.Distance(inicio.position, transform.position);
                    t2 = Mathf.Pow(h / 4.9f, 0.5f);
                    velY = Mathf.Pow(2f * h * 9.8f, 0.5f);
                    mostrar = Mathf.Round(t2 * 1000f) / 1000f;
					tiempo.text = "tiempo = " + mostrar +" s"; 
					mostrar = Mathf.Round(h * 1000f) / 1000f;
					altura.text = "altura = " + mostrar + "m";
					vf = Mathf.Round (velY * 1000f) / 1000f;
					Vfy.text = "Velocidad Final vertical =" + vf + "m/s";
                    
                }
                


            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision2d)
    {

        inicia = false;

        if (principal == true)
        {
            if (collision2d.gameObject.tag == "final")
            {
                medicion = false;
                principal = false;

                StartCoroutine("waitThreeSeconds2");
                rueda.simulated = false;

            }
            else
            {
                if (collision2d.gameObject.tag == "caida")
                {
                    rueda.simulated = false;
                    medicion = false;
                    principal = false;
                    StartCoroutine("waitThreeSeconds2");

                }

            }
        }
    }
    IEnumerator waitThreeSeconds()
    {
       
        yield return new WaitForSeconds(seg);
        inicia = true;
        rueda.simulated = true;
        


    }

 

    IEnumerator waitThreeSeconds2()
    {
       
        yield return new WaitForSeconds(1);
        RespFisica.respuesta.comp = true;
        SceneManager.LoadScene(nivel);
    }
}

