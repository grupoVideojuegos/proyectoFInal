using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    // Start is called before the first frame update
    bool showGui=false;
    public string message = "";
    void Start()
    {
        if (message == "wj")
        {
            message = "Practica de Wall Jump\nCuando te encuentres deslizandote\nen la pared Pulsa espacio + \nflecha direccion contraria";
        }
        if (message == "be")
        {
            message = "Quizas deberias ir en otra direccion";
        }
        if (message == "cae")
        {
            message = "Estas plataformas caen\nDespues de cierto tiempo\nCuidado al cruzarlas";
        }
        if (message == "mov")
        {
            message = "Estas plataformas se mueven\nDespues de cierto tiempo\nCuidado al cruzarlas";
        }
        if (message == "en")
        {
            message = "Esto es un enemigo\nPreferible no tocarlo";
        }
        if (message == "sal")
        {
            message = "Esa puerta es la salida\nSolo acercate";
        }
        if (message == "sub")
        {
            message = "Es preferible subir\nEn vez de bajar";
        }
        if (message == "fe")
        {
            message = "Solo salta, nada malo pasara";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        if (showGui) {
            GUI.Box(new Rect(0, 0, 230, 70), message,"box");
        }
            
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") showGui = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") showGui = false;
    }
}
