using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class RespFisica : MonoBehaviour
{
 
    public float vel;
    public string ver="";
    public static RespFisica respuesta;
    public compararRespuesta CompararResp;
    public string nivel;
    public string resultado;
    bool nivell;
    public bool comp;
    public bool inicia;
    // Use this for initialization
   
    void Awake()
    {
       
        if (respuesta == null)
        {
            respuesta = this;
            DontDestroyOnLoad(gameObject);
        }
        if (respuesta != this)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

		if (ver == "") { 
			inicia = true;
		}else{ 
			inicia = false;
		}
		
        if (Input.GetKeyDown(KeyCode.Escape ) && ver == "") {
            Destroy(gameObject);
        }
        if (comp == true)
        {
            Destroy(gameObject);
        }
        if (inicia == true) { 
                CompararResp = GameObject.FindWithTag("Manager").GetComponent<compararRespuesta>();
            inicia = false;
			}
     
    }

    public void comparar(Button boton)
    {
        ver = "utilizando";
        resultado = CompararResp.tpanel.text;
        vel = float.Parse(boton.GetComponentInChildren<Text>().text);
        SceneManager.LoadScene(nivel);
        nivell = true;
        if (respuesta == null)
        {
            respuesta = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (respuesta != this)
        {
            Destroy(gameObject);
        }
    }




}
