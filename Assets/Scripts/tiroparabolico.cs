using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class tiroparabolico : MonoBehaviour
{

    
    Rigidbody2D rueda;
    public string nivel;
 
    public float velocidadx;
    public float velocidadY;
    public float dist;
    public float altura;
    float h;
    float d;
    float y,x;
    float y2,x2;
    float vf;
    public Transform inicioy;
    public Transform inicio;
    public Transform objeto;
    public AudioSource sonido;
    public GameObject panel;
    float time;
    float time2=0f;
	public TextMesh distancia;
	public Text velocY;
	public Text velocX;
	public Text tiempo;
    public bool vy;
    public bool vx;
    public bool principal;
    public bool medidas;
    bool choque;
   
    //variables texto


    //otras



    //variables aleatorio

    //variables tiempo


    // Use this for initialization
    void Start()
    {
        //valor variables 
        rueda = this.gameObject.GetComponent<Rigidbody2D>();
        sonido = gameObject.GetComponent<AudioSource>();
        rueda.velocity = new Vector2(velocidadx, velocidadY);
        y = inicio.position.y;
        y2 = objeto.position.y;
        x = inicio.position.x;
        x2 = inicioy.position.x;
        //Calculo de Respuestas

    }

    // Update is called once per frame
	void FixedUpdate()
    {
        inicio.position = new Vector2(x, y);
        inicioy.position = new Vector2(x2, y2); 
        objeto.position = new Vector2(transform.position.x, y2);
        if (rueda.velocity.y >0) { 
        altura = Vector2.Distance(inicioy.position, transform.position);
        }
        if (medidas==true) { 
        velocX.text = "Velocidad Horizontal = " + velocidadx+ " m/s";
        }

        if (vy == true)
        {
            velocidadY = RespFisica.respuesta.vel;
            rueda.velocity = new Vector2(velocidadx, velocidadY);
            vy = false;
        }
        if (vx == true)
        {
            velocidadx = RespFisica.respuesta.vel;
            rueda.velocity = new Vector2(velocidadx, velocidadY);
            vx = false;
            
        }



        //Time.timeScale = 1f;
        if (panel.activeInHierarchy)
        {

        }
        else {

            rueda.simulated = true;
            rueda.velocity = new Vector2(velocidadx, GetComponent<Rigidbody2D>().velocity.y);
            if (choque == false)
            {








                if (medidas == true)
                {

                    dist = Vector2.Distance(inicio.position, objeto.position);
                    time2 = dist / velocidadx;
                    vf = (time2 * -9.8f) + velocidadY;
                    h = ((vf + velocidadY) / 2f) * time2;
                    time = Mathf.Round(dist * 1000f) / 1000f;
                    distancia.text = "Distancia = " + time + " m";
                    time = Mathf.Round(time2 * 1000) / 1000;
                    tiempo.text = "Tiempo =" + time + " s";
                    vf = Mathf.Round(vf * 100) / 100;
                    velocY.text = "Velocidad Final vertical= " + vf +" m/s";

                }

            }

        }
        
    }

    void OnCollisionEnter2D( Collision2D collision2d)
    {
        
            if (collision2d.gameObject.tag == "final" && principal==true)
            {
                if (collision2d.gameObject.tag == "final")
                {
                velocidadx = 0;
                    StartCoroutine("waitThreeSeconds");


                }
                else
                {
                    if (collision2d.gameObject.tag == "caida")
                    {
                    velocidadx = 0;

                    StartCoroutine("waitThreeSeconds");

                    }

                }
            }
        
            if (collision2d.gameObject.tag == "base" || collision2d.gameObject.tag == "Player2")
            {

            }
            else {
          
            rueda.gravityScale = 5f;
            velocidadx = 0;
            medidas = false;

        }

        

}
    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(1);
        RespFisica.respuesta.comp = true;
        SceneManager.LoadScene(nivel);
    }


}

   
