using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class calculadora : MonoBehaviour
{
    //textos
    public Text pantalla;
    public Text numero;
    //colocoar boton punto
    public Button botonpunto;
    public Button closedparen;
    public Button openparen;
    int puntos;
    int ppunto;
    float ans;
    //arrays  
    public float[] valores = new float[25];
    public string[] funciones = new string[24];
    public string[] numeros = new string[25];
    //texto numeros
    bool num;
    bool iguall;
    string textonumero;
    int n;
    //valores
    bool value;
    public int val;
    //opreadores
    bool op;
    bool op2;
    string opactual;
    public int ope;
    //quitar textos numero
    bool bnum;
    bool bnum3;
    //eliminar numeros
    bool quitar;
    //inicia operaciones matematicas
    bool inoperation;
    int fun;
    int fun2;
    int fun3;
    int fun4;
    bool ordenar;
    int ord;
    public int oper;
    int opa;
    int opa2;
    int resta;
    //parentesis
    string inicioparent;
    string finalparent;
    bool parentesis;
    int numparent;
    bool parent;
    bool bnum2;
    float tan = 1f;
    float rtan;
    bool otras;
    int numope;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //inciar multiplicacion
        //boton punto
        if (puntos == 1)
        {
            botonpunto.interactable = false;
        }
        if (bnum == true)
        {
            if (n != 0)
            {
                numeros[n] = "";
                n = n - 1;
            }
            else
            {
                numeros[n] = "";
                bnum = false;
            }
        }
        // colocar texto de numeros
        if (num == true)
        {
            if (numeros[n] != "" && n != 24)
            {
                n = n + 1;
            }
            else
            {
                numeros[n] = textonumero;
                num = false;
            }
        }
        //funciones 2
        if (op2 == true)
        {
            if (funciones[ope] != "" && ope != 23)
            {
                ope = ope + 1;
            }
            else
            {
                pantalla.text = pantalla.text + opactual + "(";
                funciones[ope] = opactual;
                ope = ope + 1;
                funciones[ope] = "(";
                numparent = numparent + 1;
                inicioparent = "" + ope;
                op2 = false;
            }
        }
        //funciones
        if (op == true)
        {
            if (funciones[ope] != "" && ope != 23)
            {
                ope = ope + 1;
            }
            else
            {
                if (opactual == "√" || opactual == "cos" || opactual == "sen" || opactual == "tan" || opactual == "tan-1" || opactual == "sen-1" || opactual == "cos-1")
                {
                    if (numparent == 0)
                    {
                        pantalla.text = pantalla.text + opactual + "(" + valores[val] + ")";
                        funciones[ope] = opactual;
                        val = val + 1;
                        textonumero = "";
                        numero.text = textonumero;
                        bnum2 = true;
                        op = false;
                    }
                    else
                    {
                        pantalla.text = pantalla.text + opactual + "(" + valores[val] + ")";
                        funciones[ope] = opactual;
                        val = val + 1;
                        textonumero = "";
                        numero.text = textonumero;
                        bnum2 = true;
                        closedparen.interactable = true;
                        op = false;
                    }
                }
                else
                {
                    pantalla.text = pantalla.text + valores[val];
                    textonumero = "";
                    numero.text = textonumero;
                    funciones[ope] = opactual;
                    val = val + 1;
                    pantalla.text = pantalla.text + funciones[ope];
                    op = false;
                }
            }
        }
        //borrar
        if (quitar == true)
        {
            numero.text = numeros[n];
            textonumero = numero.text;
            quitar = false;
            if (ppunto == n)
            {
                puntos = 0;
                if (numero.text != "")
                {
                    botonpunto.interactable = true;
                    ppunto = -1;
                }
            }
        }
        //operaciones dentro de parentesis parentesis        
        //parentesis
        if (parent == true)
        {
            if (numparent == 0)
            {
                bnum2 = true;

                closedparen.interactable = false;

            }

            if (funciones[ope] != "")
            {
                ope = ope + 1;
            }
            else
            {
                if (opactual == "(")
                {


                    funciones[ope] = opactual;
                    inicioparent = "" + ope;
                    parent = false;
                    if (bnum3 == true)
                    {
                        ope = ope + 1;
                        bnum3 = false;
                    }

                }
            }

        }
        //funciones dentro de parentesis
    }
    //Final update
    //Numeros
    public void boton(GameObject boton)
    {
        if (pantalla.text != "Error")
        {
            if (iguall == true)
            {
                bnum2 = false;
                iguall = false;
                ope = 0;
                pantalla.text = "";
            }
            if (bnum2 != true)
            {
                if (n != 24 && val != 24)
                {

                    if (boton.GetComponentInChildren<Text>().text == "ANS")
                    {
                        numero.text = "ANS";
                        textonumero = "" + ans;
                        valores[val] = float.Parse(textonumero);
                        num = true;
                        if (puntos == 0)
                        {
                            botonpunto.interactable = true;
                        }

                        if (numparent > 0)
                        {
                            closedparen.interactable = true;
                        }
                    }
                    else
                    {

                        if (numero.text != "ANS")
                        {

                            numero.text = numero.text + boton.GetComponentInChildren<Text>().text;
                            textonumero = textonumero + boton.GetComponentInChildren<Text>().text;
                            num = true;

                            valores[val] = float.Parse(textonumero);
                            if (puntos == 0)
                            {
                                botonpunto.interactable = true;
                            }

                            if (numparent > 0)
                            {
                                closedparen.interactable = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (ope != 22)
                {


                    numero.text = PlayerPrefs.GetString("userName") + " " + "Coloca un operador";

                }

            }
        }
    }
    //Boton punto
    public void punto()
    {
        if (pantalla.text != "Error")
        {
            numero.text = numero.text + ".";
            textonumero = textonumero + ".";
            puntos = 1;
            ppunto = n;
            num = true;
        }
    }
    //funciones
    public void operadores(GameObject boton)
    {
        //boton funciones    
        iguall = false;
        if (val != 23 - (2 * numparent) && pantalla.text != "Error")
        {
            if (ope == -1)
            {
                ope = ope + 1;
                val = val + 1;
            }
            closedparen.interactable = false;
            opactual = boton.GetComponentInChildren<Text>().text;
            if ((opactual == "√" || opactual == "sen" || opactual == "cos" || opactual == "tan" || opactual == "cos-1" || opactual == "sen-1" || opactual == "tan-1") && numero.text == "" && numparent == 0 && ope <= 20 && bnum2 == false)
            {
                opactual = boton.GetComponentInChildren<Text>().text;
                openparen.interactable = false;
                resta = 1;
                op2 = true;
            }
            else
            {
                if (boton.GetComponentInChildren<Text>().text != "+" && boton.GetComponentInChildren<Text>().text != "-")
                {
                    numope = numope + 1;
                }
                if (numero.text != "" && numero.text != PlayerPrefs.GetString("userName") + " " + "Coloca un operador")
                {
                    opactual = boton.GetComponentInChildren<Text>().text;
                    op = true;
                }
                else
                {
                    if (bnum2 != true && boton.GetComponentInChildren<Text>().text == "+" || bnum2 != true && boton.GetComponentInChildren<Text>().text == "-")
                    {
                        numero.text = boton.GetComponentInChildren<Text>().text;
                        textonumero = numero.text;
                    }
                    else
                    {
                        if (bnum2 == true)
                        {
                            numero.text = "";
                            opactual = boton.GetComponentInChildren<Text>().text;
                            if (opactual == "√" || opactual == "sen" || opactual == "cos" || opactual == "tan" || opactual == "cos-1" || opactual == "sen-1" || opactual == "tan-1")
                            {
                                if (ope != 22)
                                {
                                    numero.text = PlayerPrefs.GetString("userName") + " " + "Coloca un operador";
                                }
                            }

                            else
                            {
                                pantalla.text = pantalla.text + opactual;
                                if (funciones[ope] != "")
                                {
                                    ope = ope + 1;
                                }
                                funciones[ope] = opactual;
                                ope = ope + 1;
                                bnum2 = false;
                            }
                        }
                    }
                }
            }
        }
        //bloquear punto
        puntos = 0;
        botonpunto.interactable = false;
        bnum = true;
    }

    //boton retroceso
    public void borrar()
    {
        if (pantalla.text != "Error")
            if (n != 0)
            {
                numeros[n] = "";
                n = n - 1;
                valores[val] = float.Parse(numeros[n]);
                quitar = true;
            }
            else
            {
                numeros[n] = "";
                valores[val] = 0;
                botonpunto.interactable = false;
                puntos = 0;
                quitar = true;
                if (puntos == 0)
                {
                    botonpunto.interactable = false;
                }

                if (numparent > 0)
                {
                    closedparen.interactable = false;
                }
            }
    }
    //botones parentesis
    public void bparentesis1(GameObject boton)
    {
        if (numparent < 8 && pantalla.text != "Error")
        {
            if (ope != 22)
            {
                openparen.interactable = false;
                if (bnum2 != true)
                {
                    if (numero.text == "")
                    {
                        pantalla.text = pantalla.text + boton.GetComponentInChildren<Text>().text;
                        opactual = boton.GetComponentInChildren<Text>().text;
                        numparent = numparent + 1;
                        parent = true;
                    }
                    else
                    {
                        pantalla.text = pantalla.text + boton.GetComponentInChildren<Text>().text;
                        opactual = boton.GetComponentInChildren<Text>().text;
                        numparent = numparent + 1;
                        pantalla.text = pantalla.text + valores[val];
                        val = val + 1;
                        textonumero = "";
                        numero.text = "";
                        botonpunto.interactable = true;
                        parent = true;
                        bnum2 = true;
                        bnum3 = true;
                    }
                }
                else
                {

                    numero.text = PlayerPrefs.GetString("userName") + " " + "Coloca un operador";
                    openparen.interactable = true;

                }
            }
        }
    }
    //Parentesis 2
    public void bparentesis2(GameObject boton)
    {

        if (pantalla.text != "Error")
        {
            if (numparent > 0)
            {
                openparen.interactable = true;
                if (numero.text != "")
                {
                    pantalla.text = pantalla.text + valores[val];
                    val = val + 1;
                    textonumero = "";
                    numero.text = "";
                    if (boton.GetComponentInChildren<Text>().text == ")")
                    {
                        pantalla.text = pantalla.text + boton.GetComponentInChildren<Text>().text;
                    }
                    opactual = ")";

                    puntos = 0;
                    botonpunto.interactable = false;
                    bnum = true;
                    bnum2 = true;
                    numparent = numparent - 1;
                    parentesis = true;
                }
                else
                {
                    if (boton.GetComponentInChildren<Text>().text == ")")
                    {
                        pantalla.text = pantalla.text + boton.GetComponentInChildren<Text>().text;
                    }
                    opactual = ")";
                    numparent = numparent - 1;
                    puntos = 0;
                    botonpunto.interactable = false;
                    bnum = true;
                    bnum2 = true;
                    parentesis = true;
                }
                for (; parentesis == true;)
                {
                    if (numparent == 0)
                    {
                        bnum2 = true;
                        closedparen.interactable = false;
                    }

                    if (funciones[ope] != "")
                    {
                        ope = ope + 1;
                    }
                    else
                    {
                        funciones[ope] = opactual;
                        finalparent = "" + ope;
                        parent = false;
                        parentesis = false;
                    }
                }
                opa2 = int.Parse(inicioparent);
                ord = int.Parse(inicioparent) - resta;
                fun = int.Parse(inicioparent);
                fun2 = int.Parse(inicioparent);
                fun3 = int.Parse(inicioparent);
                fun4 = int.Parse(inicioparent);
                funciones[int.Parse(inicioparent)] = "";
                funciones[int.Parse(finalparent)] = "";
                ope = ope - 1;
                opa = int.Parse(finalparent);
                inoperation = true;
                //operaciones dentro de parentesis
                for (; inoperation == true;)
                {
                    //for ordenar
                    for (; ordenar == true;)
                    {
                        if (valores[ord] == 0 && ord != (int.Parse(finalparent) - resta))
                        {
                            valores[ord] = valores[ord + 1];
                            valores[ord + 1] = 0;
                            ord = ord + 1;
                        }
                        else
                        {
                            if (ord != opa)
                            {
                                ord = ord + 1;
                            }
                        }
                        if (funciones[opa2 + 1] == "" && opa2 != opa)
                        {
                            funciones[opa2 + 1] = funciones[opa2 + 2];
                            funciones[opa2 + 2] = "";
                            opa2 = opa2 + 1;
                        }
                        else
                        {
                            if (opa2 != opa)
                            {
                                opa2 = opa2 + 1;
                            }
                        }
                        if (opa2 == opa && ord == (int.Parse(finalparent) - resta))
                        {

                            opa2 = int.Parse(inicioparent);
                            ord = int.Parse(inicioparent) - resta;
                            fun = int.Parse(inicioparent);
                            fun2 = int.Parse(inicioparent);
                            fun3 = int.Parse(inicioparent);
                            fun4 = int.Parse(inicioparent);
                            val = val - 1;

                            ope = ope - 1;

                            opa = int.Parse(finalparent);
                            ordenar = false;
                            inoperation = true;
                        }
                    }
                    //for exponente
                    for (; fun4 != opa && ordenar == false; fun4++)
                    {

                        if (funciones[fun4 + 1] == "^")
                        {
                            valores[fun4 - resta] = Mathf.Pow(valores[fun4 - resta], valores[fun4 - resta + 1]);
                            valores[fun4 - resta + 1] = 0;
                            funciones[fun4 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                    }
                    //for 1
                    for (; fun3 != opa && ordenar == false; fun3++)
                    {
                        if (funciones[fun3 + 1] == "√")
                        {
                            valores[fun3 - resta] = Mathf.Pow(valores[fun3 - resta], 0.5f);
                            funciones[fun3 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                            otras = true;
                        }
                        if (funciones[fun3 + 1] == "sen-1")
                        {
                            if (valores[fun3 - resta] <= 1 && valores[fun3] >= -1)
                            {
                                valores[fun3 - resta] = Mathf.Round(Mathf.Asin(valores[fun3 - resta]) * Mathf.Rad2Deg * 100) / 100;
                                funciones[fun3 + 1] = "";
                                ordenar = true;
                                numope = numope - 1;
                                otras = true;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun3 = opa;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun3 + 1] == "cos-1")
                        {
                            if (valores[fun3] <= 1 && valores[fun3] >= -1)
                            {
                                valores[fun3 - resta] = Mathf.Round(Mathf.Acos(valores[fun3 - resta]) * Mathf.Rad2Deg * 100) / 100;
                                funciones[fun3 + 1] = "";
                                ordenar = true;
                                numope = numope - 1;
                                otras = true;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun3 = opa;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun3 + 1] == "tan-1")
                        {
                            valores[fun3 - resta] = Mathf.Round(Mathf.Atan(valores[fun3 - resta]) * Mathf.Rad2Deg * 100) / 100;
                            funciones[fun3 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                            otras = true;
                        }
                        if (funciones[fun3 + 1] == "tan")
                        {
                            tan = 1;
                            for (; tan != 1000003;)
                            {
                                rtan = valores[fun3 - resta] / (90 * tan);
                                if (rtan == 1)
                                {
                                    tan = 10003;
                                    pantalla.text = "Error";
                                    fun3 = opa;
                                    ordenar = true;
                                    inoperation = false;
                                }
                                else
                                {
                                    tan = tan + 2;
                                }
                            }
                            valores[fun3 - resta] = Mathf.Round(Mathf.Tan(Mathf.Deg2Rad * valores[fun3 - resta]) * 1000000) / 1000000;

                            funciones[fun3 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                            otras = true;
                        }
                        if (funciones[fun3 + 1] == "sen")
                        {
                            valores[fun - resta] = Mathf.Round(Mathf.Sin(Mathf.Deg2Rad * valores[fun3 - resta]) * 1000000) / 1000000;
                            funciones[fun3 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                            otras = true;
                        }

                        if (funciones[fun3 + 1] == "cos")
                        {
                            valores[fun3 - resta] = Mathf.Round(Mathf.Cos(Mathf.Deg2Rad * valores[fun - resta]) * 1000000) / 1000000;
                            funciones[fun3 + 1] = "";
                            ordenar = true;
                            numope = numope - 1;
                            otras = true;
                        }
                    }
                    if (otras == true && ordenar == false)
                    {
                        otras = false;
                        val = val + 1;
                    }
                    //final for 1
                    //Multiplicacion, division,tan,sin,cos,expo,radicacion
                    for (; fun != opa && ordenar == false; fun++)
                    {
                        if (funciones[fun + 1] == "/")
                        {
                            if (valores[fun - resta + 1] != 0)
                            {
                                valores[fun - resta] = valores[fun - resta] / valores[fun - resta + 1];
                                valores[fun - resta + 1] = 0;
                                funciones[fun + 1] = "";
                                ordenar = true;
                                numope = numope - 1;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun = opa;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun + 1] == "*")
                        {
                            valores[fun - resta] = valores[fun - resta] * valores[fun - resta + 1];
                            valores[fun - resta + 1] = 0;
                            funciones[fun + 1] = "";
                            numope = numope - 1;
                            ordenar = true;
                        }
                    }
                    //final for    
                    for (; fun2 != opa && ordenar == false; fun2++)
                    {
                        if (funciones[fun2 + 1] == "+")
                        {
                            valores[fun2 - resta] = valores[fun2 - resta] + valores[fun2 - resta + 1];
                            valores[fun2 - resta + 1] = 0;
                            funciones[fun2 + 1] = "";
                            ordenar = true;
                        }
                        if (funciones[fun2 + 1] == "-")
                        {
                            valores[fun2 - resta] = valores[fun2 - resta] - valores[fun2 - resta + 1];
                            valores[fun2 - resta + 1] = 0;
                            funciones[fun2 + 1] = "";


                            ordenar = true;
                        }
                        if (ordenar == false)
                        {
                            if (oper == 0)
                            {


                                if (boton.GetComponentInChildren<Text>().text == "(")
                                {
                                    inoperation = false;

                                }
                                else
                                {

                                    inoperation = false;
                                }

                            }
                            else
                            {




                                inoperation = false;
                            }
                        }
                    }
                }
            }
            resta = 0;

            //final parentesis 2
        }
    }
    //boton igual
    public void igual()
    {
        if (pantalla.text != "Error")
        {
            val = 0;
            ope = 0;
            fun = 0;
            fun2 = 0;
            ord = 0;
            oper = 0;
            fun3 = 0;
            fun4 = 0;
            ordenar = false;
            numero.text = "";
            pantalla.text = "";
            inoperation = true;

            //inicio de operaciones         
            for (; inoperation == true;)
            {
                if (numparent == 0)
                {

                    //for ordenar
                    for (; ordenar == true;)
                    {
                        if (valores[ord] == 0 && ord != 23)
                        {
                            valores[ord] = valores[ord + 1];
                            valores[ord + 1] = 0;
                            ord = ord + 1;
                        }
                        else
                        {
                            if (ord != 23)
                            {
                                ord = ord + 1;
                            }
                        }
                        if (funciones[oper] == "" && oper != 22)
                        {
                            funciones[oper] = funciones[oper + 1];
                            funciones[oper + 1] = "";
                            oper = oper + 1;
                        }
                        else
                        {
                            if (oper != 22)
                            {
                                oper = oper + 1;
                            }
                        }
                        if (ord == 23 && oper == 22)
                        {
                            ord = 0;
                            oper = 0;
                            fun = 0;
                            fun2 = 0;
                            fun3 = 0;
                            ordenar = false;
                            inoperation = true;
                        }
                    }
                    //inicio for 1
                    for (; fun3 != 22 && ordenar == false; fun3++)
                    {


                        if (funciones[fun3] == "√")
                        {
                            valores[fun3] = Mathf.Pow(valores[fun3], 0.5f);

                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                        if (funciones[fun3] == "^")
                        {
                            valores[fun3] = Mathf.Pow(valores[fun3], valores[fun3 + 1]);
                            valores[fun3 + 1] = 0;
                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                        if (funciones[fun3] == "sen-1")
                        {
                            if (valores[fun3] <= 1 && valores[fun3] >= -1)
                            {
                                valores[fun3] = Mathf.Round(Mathf.Asin(valores[fun3]) * Mathf.Rad2Deg * 100) / 100;
                                funciones[fun3] = "";
                                ordenar = true;
                                numope = numope - 1;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun3 = 22;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun3] == "cos-1")
                        {
                            if (valores[fun3] <= 1 && valores[fun3] >= -1)
                            {
                                valores[fun3] = Mathf.Round(Mathf.Acos(valores[fun3]) * Mathf.Rad2Deg * 100) / 100;
                                funciones[fun3] = "";
                                ordenar = true;
                                numope = numope - 1;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun3 = 22;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun3] == "tan-1")
                        {
                            valores[fun3] = Mathf.Round(Mathf.Atan(valores[fun3]) * Mathf.Rad2Deg * 100) / 100;
                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                        if (funciones[fun3] == "tan")
                        {
                            tan = 1;
                            for (; tan != 1000003;)
                            {
                                rtan = valores[fun3] / (90 * tan);
                                if (rtan == 1)
                                {
                                    tan = 25;
                                    pantalla.text = "Error";
                                    fun3 = 22;
                                    ordenar = true;
                                    inoperation = false;

                                }
                                else
                                {
                                    tan = tan + 2;
                                }
                            }
                            valores[fun3] = Mathf.Round(Mathf.Tan(Mathf.Deg2Rad * valores[fun3]) * 1000000) / 1000000;
                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                        if (funciones[fun3] == "sen")
                        {
                            valores[fun3] = Mathf.Round(Mathf.Sin(Mathf.Deg2Rad * valores[fun3]) * 1000000) / 1000000;

                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                        if (funciones[fun3] == "cos")
                        {
                            valores[fun3] = Mathf.Round(Mathf.Cos(Mathf.Deg2Rad * valores[fun3]) * 1000000) / 1000000;

                            funciones[fun3] = "";
                            ordenar = true;
                            numope = numope - 1;
                        }
                    }
                    //final for 1

                    //Multiplicacion, division,tan,sin,cos,expo,radicacion
                    for (; fun != 22 && ordenar == false; fun++)
                    {
                        if (funciones[fun] == "/")
                        {
                            if (valores[fun + 1] != 0)
                            {
                                valores[fun] = valores[fun] / valores[fun + 1];
                                valores[fun + 1] = 0;
                                funciones[fun] = "";
                                ordenar = true;
                                numope = numope - 1;
                            }
                            else
                            {
                                pantalla.text = "Error";
                                fun = 22;
                                ordenar = true;
                                inoperation = false;
                            }
                        }
                        if (funciones[fun] == "*")
                        {
                            valores[fun] = valores[fun] * valores[fun + 1];
                            valores[fun + 1] = 0;
                            funciones[fun] = "";
                            numope = numope - 1;
                            ordenar = true;
                        }
                    }
                    //final for            
                    ord = 0;
                    oper = 0;
                    for (; fun2 != 22 && ordenar == false; fun2++)
                    {
                        if (funciones[fun2] == "+")
                        {
                            valores[fun2] = valores[fun2] + valores[fun2 + 1];
                            valores[fun2 + 1] = 0;
                            funciones[fun2] = "";
                            ordenar = true;
                        }
                        if (funciones[fun2] == "-")
                        {

                            valores[fun2] = valores[fun2] - valores[fun2 + 1];
                            valores[fun2 + 1] = 0;
                            funciones[fun2] = "";
                            ordenar = true;
                        }
                    }//final for
                    if (ordenar == false)
                    {
                        inoperation = false;
                        bnum = true;
                        bnum2 = true;
                        ans = valores[0];
                        pantalla.text = "" + valores[0];
                        valores[val] = ans;
                        ope = -1;
                        iguall = true;
                        textonumero = "";

                        bnum = true;
                        botonpunto.interactable = false;
                    }
                }
                else
                {
                    numparent = numparent - 1;
                }
            }//final IGUAL       
        }
    }
    //boton borrar todo
    public void AC()
    {

        val = 24;
        ope = 23;
        n = 24;
        oper = 0;
        resta = 0;
        openparen.interactable = true;
        closedparen.interactable = false;
        bnum = true;
        bnum2 = false;
        puntos = 0;
        botonpunto.interactable = false;
        parent = false;
        textonumero = "";
        numero.text = "";
        pantalla.text = "";
        for (; val > 0 && n > 0;)
        {
            for (; ope > 0;)
            {
                funciones[ope] = "";
                ope = ope - 1;
            }
            val = val - 1;
            numeros[n] = "";
            n = n - 1;
        }
        iguall = false;
        numeros[n] = "";
        valores[val] = 0;
        funciones[ope] = "";
        val = 0;
        opactual = "";
        ope = 0;
        oper = 0;
        n = 0;
        inicioparent = "";
        finalparent = "";
        numparent = 0;
    }
}
