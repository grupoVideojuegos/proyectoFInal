using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{

    private float tiempoDisparo;
    [SerializeField] float iniciarTiempoDisparo;
    [SerializeField] GameObject bala;
    private Transform jugador; 

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindObjectOfType<Jugador>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoDisparo <= 0)
        {
            Instantiate(bala, transform.position, Quaternion.identity);
            tiempoDisparo = iniciarTiempoDisparo;
        }
        else
        {
            tiempoDisparo -= Time.deltaTime;
        }
    }
}
